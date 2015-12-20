using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Quiz.Controller
{
    class DataFileController
    {
        static readonly string PasswordHash = "!@#$paSs";
        static readonly string SaltKey = "#S@LtKeY#"; // atleast 8 bytes
        static readonly string VIKey = "1A2b3C4D5e6f7G8R";//need 16 bytes
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        public void write2File(string fileUrl, bool bo, string text)
        {
            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(fileUrl, bo, Encoding.Unicode);
                sw.WriteLine(Encrypt(text));
                sw.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message);
            }
        }
        public List<Model.Question> readListFromFile(string url)
        {
            string[] lines;
            Model.Question q;
            List<Model.Question> list = new List<Model.Question>();

            int count;
            try
            {
                lines = System.IO.File.ReadAllLines(url);
                count = int.Parse(Decrypt(lines[1]));
                int y = 2;
                for (int i = 0; i < count; i++)
                {
                    q = new Model.Question();
                    q.Id = int.Parse(Decrypt(lines[y++]));
                    q.SubId = Decrypt(lines[y++]);
                    q.Content = Decrypt(lines[y++]);
                    q.Opt1 = Decrypt(lines[y++]);
                    q.Opt2 = Decrypt(lines[y++]);
                    q.Opt3 = Decrypt(lines[y++]);
                    q.Opt4 = Decrypt(lines[y++]);
                    q.Answer = Decrypt(lines[y++]);
                    
                    q.UserAdd = Decrypt(lines[y++]);
                    string temp = Decrypt(lines[y++]).ToString();
                    q.DateAdd = DateTime.ParseExact(temp.Substring(0,10),"MM/dd/yyyy",null);
                    q.Note = Decrypt(lines[y++]);
                    list.Add(q);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi file data! \n" + e.Message, "Error");
            }
            return list;
        }
        public string readPassFromFile(string url)
        {
            string pass = "";
            try
            {
                string[] lines = System.IO.File.ReadAllLines(url);
                pass = Decrypt(lines[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi file data!", "Error");
            }
            return pass;
        }
    }
}

using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web.Security;
using System.Text;
using System.Web.Helpers;
using System.Windows;

namespace Core.Controller
{
    public class AddUserController
    {
        Entities qz = new Entities();
        public bool AddUser(string username, string password)
        {
            //try
            //{
                AspNetUser user = new AspNetUser();
                Guid g = Guid.NewGuid();
                user.Id = g.ToString();
                user.Email = username;
                user.EmailConfirmed = false;
                user.PhoneNumberConfirmed = false;
                user.TwoFactorEnabled = false;
                user.LockoutEnabled = true;
                user.AccessFailedCount = 0;
                user.UserName = username;
                string temp = Crypto.HashPassword(password);
                user.PasswordHash = temp;
                qz.AspNetUsers.Add(user);
                qz.SaveChanges();
                return true;
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("Adduser: " + e.Message);
            //    return false;
            //}

        }
        public bool CheckLogin(string username, string password)
        {
            try
            {


                AspNetUser r = qz.AspNetUsers.Where(t => t.Email == username).SingleOrDefault();
                if (r != null)
                {
                    if(ValidateCredentials(r.PasswordHash,password))
                    {
                        Thongtindangnhap.Username = username;
                        Thongtindangnhap.Password = password;
                        Thongtindangnhap.IsLogin = true;
                        return true;
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi kiểm tra đăng nhập: "+e.Message);
                return false;
            }
            return false;
        }
        public bool Logout()
        {
            try
            {
                Thongtindangnhap.Username = "";
                Thongtindangnhap.Password = "";
                Thongtindangnhap.IsLogin = false;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
        public AspNetUser FindUserByUsername(string username)
        {
            try
            {
                return qz.AspNetUsers.Where(t => t.Email == username).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /*private static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        private static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }*/

        public bool ValidateCredentials(string hashedPassword, string password)
        {
            var doesPasswordMatch = Crypto.VerifyHashedPassword(hashedPassword, password);
            return doesPasswordMatch;
        }
        
        
        internal static string CreateString(int stringLength)
        {
            Random rd = new Random();
            const string allowedChars = "abcdefghijkmnopqrstuvwxyz0123456789-";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
}
    }
}

using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Quiz.Controller
{
    class AddUserController
    {
        QuizDbEntities qz = new QuizDbEntities();
        public bool AddUser(string username, string password)
        {
            try
            {
                User user = new User();
                user.Name = username;
                user.Matkhau = password;
                qz.Users.Add(user);
                qz.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Adduser: " + e.Message);
                return false;
            }

        }
        public bool CheckLogin(string username, string password)
        {
            try
            {
                User r = qz.Users.Where(t => t.Name == username && t.Matkhau == password).SingleOrDefault();
                if (r != null)
                {
                    Thongtindangnhap.Username = username;
                    Thongtindangnhap.Password = password;
                    Thongtindangnhap.IsLogin = true;
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Lỗi kiểm tra đăng nhập");
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
        public User FindUserByUsername(string username)
        {
            try
            {
                return qz.Users.Where(t => t.Name == username).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using Quiz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public static class Thongtindangnhap
    {
        private static string username;
        private static string password;
        private static bool isLogin;
        public static string Username
        {
            set { username = value; }
            get { return username; }
        }
        public static string Password
        {
            set { password = value; }
            get { return password; }
        }
        public static bool IsLogin
        {
            set { isLogin = value; }
            get { return isLogin; }
        }
    }
}

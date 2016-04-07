
namespace Core.Model
{
    public static class Thongtindangnhap
    {
        private static string username;
        private static string password;
        private static bool isLogin;
        private static string userId;

        public static string UserId
        {
            get { return Thongtindangnhap.userId; }
            set { Thongtindangnhap.userId = value; }
        }
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

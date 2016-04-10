using Core.Interface;
using Core.Model;
using System;
using System.Linq;
using System.Web.Helpers;

namespace Core.Controller
{
    public class UserHandle : IUser
    {
        public bool Add(string username, string password)
        {
            AspNetUser user = new AspNetUser();
            Guid g = Guid.NewGuid();
            user.Id = g.ToString();
            user.Email = username;
            user.EmailConfirmed = false;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
            user.LockoutEnabled = true;
            user.AccessFailedCount = 0;
            user.UserName = username;
            string temp = Crypto.HashPassword(password);
            user.PasswordHash = temp;
            DataHelper<Entities, AspNetUser>.Add(user);
            return true;
        }


        public bool AuthenticateLogin(string username, string password)
        {
            AspNetUser r = DataHelper<Entities, AspNetUser>.FindBy(t => t.Email.Equals(username)).SingleOrDefault();
            if (r != null)
            {
                if (ValidateCredentials(r.PasswordHash, password))
                {
                    Thongtindangnhap.Username = username;
                    Thongtindangnhap.Password = password;
                    Thongtindangnhap.IsLogin = true;
                    Thongtindangnhap.UserId = r.Id;
                    return true;
                }

            }
            return false;
        }

        public bool Logout()
        {
            Thongtindangnhap.Username = "";
            Thongtindangnhap.Password = "";
            Thongtindangnhap.IsLogin = false;
            return true;
        }

        public AspNetUser GetUserByEmail(string email)
        {
            return DataHelper<Entities, AspNetUser>.FindBy(t => t.Email.Equals(email)).SingleOrDefault();
        }
        private bool ValidateCredentials(string hashedPassword, string password)
        {
            var doesPasswordMatch = Crypto.VerifyHashedPassword(hashedPassword, password);
            return doesPasswordMatch;
        }


        public AspNetUser GetUserById(string id)
        {
            return DataHelper<Entities, AspNetUser>.FindByPrimaryKey(id);
        }
    }
}

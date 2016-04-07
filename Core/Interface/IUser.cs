using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    interface IUser
    {
        bool Add(string username, string password);
        bool AuthenticateLogin(string username, string password);
        bool Logout();
        AspNetUser GetUserByEmail(string email);
        AspNetUser GetUserById(string id);
    }
}

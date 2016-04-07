using Core.Model;

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

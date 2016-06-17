using Core.Controller;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizWebApp.Controllers
{
    public class UserAPIController : ApiController
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello world";
        }
        [HttpGet]
        public UserAPI getUser(string email)
        {
            UserHandle userHandle = new UserHandle();
            AspNetUser user = userHandle.GetUserByEmail(email);
            UserAPI userapi = new UserAPI(user.Id,user.Email);
            return userapi;
        }
        [HttpGet]
        public List<News> getNews()
        {
            NewsHandle handle = new NewsHandle();
            return handle.GetAllNews();
        }
        [HttpGet] 
        public bool ValidateLogin(string username, string password)
        {
            var result = new UserHandle().Authenticate(username, password);
            return result;
        }
        [HttpGet]
        public List<History> getHistory(string userid)
        {
            AchievementHandle handle = new AchievementHandle();
            List<History> history = new List<History>();
            history = handle.GetHistoryOfUser(userid);
            return history;
        }
        [HttpGet]
        public List<Info> getInfo(string userid)
        {
            AchievementHandle handle = new AchievementHandle();
            List<Info> info = new List<Info>();
            info = handle.GetInfoOfUser(userid);
            return info;
        }

    }
    public class UserAPI
    {
        public UserAPI(string userid, string email)
        {
            this.UserId = userid;
            this.Email = email;
        }
        public string UserId { set; get; }
        public string Email { set; get; }
    }
}

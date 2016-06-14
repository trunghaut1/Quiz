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
    public class UserController : ApiController
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello world";
        }
        [HttpGet]
        public AspNetUser getUser()
        {
            UserHandle userHandle = new UserHandle();
            return userHandle.GetUserByEmail("clone@gmail.com");
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
    }
}

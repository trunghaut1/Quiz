using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizWebApp.Services
{
    public class HistoryAPIController : ApiController
    {
        [HttpGet]
        public string getHistory()
        {
            return "hehehe";
        }
    }
}

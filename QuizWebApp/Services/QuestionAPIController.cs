using Core.Controller;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizWebApp.Services
{
    public class QuestionAPIController : ApiController
    {
        [HttpGet]
        public List<Question> getQuestion(string type, int number)
        {
            QuestionHandle handle = new QuestionHandle();
            List<Question> list = new List<Question>();
            list = handle.GetQuestionBySubjectNameAndQuantity(type, number);
                return list;
        }
    }
    class QuestionAPI {
        public int Id { get; set; }
        public string SubId { get; set; }
        public string Content { get; set; }
        public string Opt1 { get; set; }
        public string Opt2 { get; set; }
        public string Opt3 { get; set; }
        public string Opt4 { get; set; }
        public string Answer { get; set; }
        public System.DateTime DateAdd { get; set; }
        public string UserAdd { get; set; }
        public string Note { get; set; }
    }
}

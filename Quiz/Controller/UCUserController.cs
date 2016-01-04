using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.Controller
{
    class UCUserController
    {
        QuizDbEntities qz = new QuizDbEntities();
        public User getUser()
        {
            return qz.Users.FirstOrDefault();
        }
        public List<Info> getInfo(long UID)
        {
            List<Info> list = new List<Info>();
            list = qz.Infoes.Where(t => t.UserId == UID).ToList();
            return list;
        }
        public List<History> getHistory()
        {
            List<History> list = new List<History>();
            list = qz.Histories.OrderByDescending(t=>t.DateTime).Take(10).ToList();
            return list;
        }
    }
}

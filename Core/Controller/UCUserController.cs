using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Controller
{
    public class UCUserController
    {
        Entities qz = new Entities();
        public AspNetUser getUser()
        {
            return qz.AspNetUsers.FirstOrDefault();
        }
        public List<Info> getInfo(string UID)
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

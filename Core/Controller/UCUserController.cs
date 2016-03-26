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
        public AspNetUser getUser(string id)
        {
            return qz.AspNetUsers.Where(t=>t.Id.Equals(id)).FirstOrDefault();
        }
        public List<Info> getInfo(string UID)
        {
            List<Info> list = new List<Info>();
            list = qz.Infoes.Where(t => t.UserId == UID).ToList();
            return list;
        }
        public List<History> getHistory(string id)
        {
            List<History> list = new List<History>();
            list = qz.Histories.Where(t=>t.UserId.Equals(id)).OrderByDescending(t=>t.DateTime).Take(10).ToList();
            return list;
        }
    }
}

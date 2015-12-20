using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.Controller
{
    class TinhdiemController
    {
        QuizDbEntities qz = new QuizDbEntities();
        public void AddInfo(Info inf)
        {
            var ori = qz.Infoes.Find(inf.SubId,inf.UserId);
            if(ori!=null)
            {
                qz.Entry(ori).CurrentValues.SetValues(inf);
                qz.SaveChanges();
            }
        }
        public void AddHistory(History his)
        {
            qz.Histories.Add(his);
            qz.SaveChanges();
        }
    }
}

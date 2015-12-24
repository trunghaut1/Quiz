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
        public bool AddInfo(Info inf)
        {
            try
            {
                var ori = qz.Infoes.Find(inf.SubId, inf.UserId);
                if (ori != null)
                {
                    ori.NumAnswer += inf.NumAnswer;
                    ori.NumAnswerTrue += inf.NumAnswerTrue;
                    ori.TimeUse += inf.TimeUse;
                    qz.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
        public bool AddHistory(History his)
        {
            try
            {
                qz.Histories.Add(his);
                qz.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
    }
}

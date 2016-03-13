using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Controller
{
    public class TinhdiemController
    {
        Core.Model.Entities qz = new Entities();
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

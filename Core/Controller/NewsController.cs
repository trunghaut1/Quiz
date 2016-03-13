using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controller
{
    public class NewsController
    {
        Entities qz;
        private void openDb()
        {
            qz = new Entities();
        }
        public List<News> get4LatestNews()
        {
            //try
            //{
                openDb();
                //return qz.News.ToList();
                return qz.News.OrderByDescending(t => t.date).Take(4).ToList();
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("Lỗi: " + e);
            //    return null;
            //}
        }
        public List<News> get4TopNews()
        {
            openDb();
            return qz.News.OrderByDescending(t => t.view_count).Take(4).ToList();
        }
    }
}

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
            try
            {
                openDb();
                //return qz.News.ToList();
                return qz.News.OrderByDescending(t => t.date).Take(4).ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("Lỗi: " + e);
                return null;
            }
        }
        public List<News> get4TopNews()
        {
            openDb();
            return qz.News.OrderByDescending(t => t.view_count).Take(4).ToList();
        }
        public List<News> get10NewsByIndex(int index)
        {
            openDb();
            return qz.News.OrderByDescending(t => t.date).Skip((index-1) * 10).Take(10).ToList();
        }
        public int getSumNews()
        {
            openDb();
            return qz.News.Count();
        }
        public News getNewsById(int id)
        {
            openDb();
            return qz.News.Find(id);
        }
        public List<News> getNewsByCat(int id)
        {
            openDb();
            return qz.News.Where(t => t.type.Equals(id)).ToList();
        }
        public int getTotalNewsByCat(int id)
        {
            openDb();
            return qz.News.Where(t=>t.type.Equals(id)).Count();
        }
        public List<News> get10NewsTypeByIndex(int index, int id)
        {
            openDb();
            return qz.News.Where(t=>t.type.Equals(id)).OrderByDescending(t => t.date).Skip((index - 1) * 10).Take(10).ToList();
        }
        public List<News> get10NewsSearchByIndex(int index, string keyword)
        {
            openDb();
            return qz.News.Where(t => t.title.Contains(keyword)).OrderByDescending(t => t.date).Skip((index - 1) * 10).Take(10).ToList();
        }
        public int getTotalNewsBySearch(string keyword)
        {
            openDb();
            return qz.News.Where(t => t.title.Contains(keyword)).Count();
        }
        public List<NewsType> getNewsType()
        {
            openDb();
            return qz.NewsTypes.ToList();
        }
        public int deleteNews(int id)
        {
            openDb();
            News news = qz.News.Single(t => t.id.Equals(id));
            qz.News.Remove(news);
            return qz.SaveChanges();
        }
        public int saveNews(News news)
        {
            openDb();
            qz.News.Add(news);
            return qz.SaveChanges();
        }

        public int saveEditNews(News n)
        {
            openDb();
            News news = qz.News.Find(n.id);
            news.date = n.date;
            news.img_link = n.img_link;
            news.text = n.text;
            news.title = n.title;
            news.type = n.type;
            news.video_link = n.video_link;
            qz.News.Add(news);
            return qz.SaveChanges();
        }

        public int increaseViewCount(int id)
        {
            openDb();
            News n = qz.News.Find(id);
            if(n!=null)
            {
                n.view_count += 1;
            }
            return qz.SaveChanges();
        }
    }
}

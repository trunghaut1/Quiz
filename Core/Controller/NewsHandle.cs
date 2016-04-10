using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Core.Interface;

namespace Core.Controller
{
    public class NewsHandle : INews
    {
        public bool AddNews(News news)
        {
            DataHelper<Entities, News>.Add(news);
            return true;
        }

        public bool EditNews(News news)
        {
            DataHelper<Entities, News>.AddOrUpdate(news);
            return true;
        }

        public bool DeleteNews(int id)
        {
            News news = DataHelper<Entities, News>.FindByPrimaryKey(id);
            DataHelper<Entities, News>.Remove(news);
            return true;
        }

        public bool AddNewsTypeType(NewsType newsType)
        {
            DataHelper<Entities, NewsType>.Add(newsType);
            return true;
        }

        public bool EditNewsType(NewsType newsType)
        {
            DataHelper<Entities, NewsType>.Edit(newsType);
            return true;
        }

        public bool DeleteNewsType(int id)
        {
            NewsType newsType = DataHelper<Entities, NewsType>.FindByPrimaryKey(id);
            DataHelper<Entities, NewsType>.Remove(newsType);
            return true;
        }

        public List<News> Get4LastestNews()
        {
            return DataHelper<Entities, News>.GetAll().OrderByDescending(t => t.date).Take(4).ToList();
        }

        public List<News> Get4TopNews()
        {
            return DataHelper<Entities, News>.GetAll().OrderByDescending(t => t.view_count).Take(4).ToList();
        }

        public List<News> Get10NewsByPageIndex(int index)
        {
            return DataHelper<Entities, News>.GetAll().OrderByDescending(t => t.date).Skip((index - 1) * 10).Take(10).ToList(); ;
        }

        public int GetSumNews()
        {
            return DataHelper<Entities, News>.GetAll().Count();
        }

        public News GetNewsById(int id)
        {
            return DataHelper<Entities, News>.FindByPrimaryKey(id);
        }

        public List<News> GetNewsByCatalogue(int id)
        {
            return DataHelper<Entities, News>.FindBy(t => t.type.Equals(id)).ToList();
        }

        public int GetSumNewsByCatalogue(int id)
        {
            return DataHelper<Entities, News>.FindBy(t => t.type.Equals(id)).Count();
        }

        public List<News> Get10NewsByTypeAndPageIndex(int id, int index)
        {
            return DataHelper<Entities, News>.FindBy(t => t.type.Equals(id)).OrderByDescending(t => t.date).Skip((index - 1) * 10).Take(10).ToList();
        }

        public List<News> Get10NewsBySearchAndPageIndex(string key, int index)
        {
            return DataHelper<Entities, News>.FindBy(t => t.title.Contains(key)).OrderByDescending(t => t.date).Skip((index - 1) * 10).Take(10).ToList();
        }

        public int GetSumNewsBySearch(string key)
        {
            return DataHelper<Entities, News>.FindBy(t => t.title.Contains(key)).Count();
        }

        public List<NewsType> GetNewsType()
        {
            return DataHelper<Entities, NewsType>.GetAll();
        }

        public void IncreaseViewCountNews(int id)
        {
            News n = DataHelper<Entities, News>.FindByPrimaryKey(id);
            if (n != null)
            {
                n.view_count += 1;
            }
            DataHelper<Entities, News>.Edit(n);
        }
    }
}

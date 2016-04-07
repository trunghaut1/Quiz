using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    interface INews
    {
        bool AddNews(News news);
        bool EditNews(News news);
        bool DeleteNews(int id);
        bool AddNewsTypeType(NewsType newsType);
        bool EditNewsType(NewsType newsType);
        bool DeleteNewsType(int id);
        List<News> Get4LastestNews();
        List<News> Get4TopNews();
        List<News> Get10NewsByPageIndex(int index);
        int GetSumNews();
        News GetNewsById(int id);
        List<News> GetNewsByCatalogue(int id);
        int GetSumNewsByCatalogue(int id);
        List<News> Get10NewsByTypeAndPageIndex(int id, int index);
        List<News> Get10NewsBySearchAndPageIndex(string key, int index);
        int GetSumNewsBySearch(string key);
        List<NewsType> GetNewsType();
        void IncreaseViewCountNews(int id);
    }
}

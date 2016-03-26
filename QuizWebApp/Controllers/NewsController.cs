using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizWebApp.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsController ctr = new Core.Controller.NewsController();
            _list = ctr.get10NewsByIndex(1);
            return View(_list);
        }
        public ActionResult Create()
        {
            Core.Controller.NewsController ctr = new Core.Controller.NewsController();
            List<Core.Model.NewsType> _list = ctr.getNewsType();
            IEnumerable<SelectListItem> selectList = 
            from c in _list
            select new SelectListItem
            {
    	        Text = c.name,
    	        Value = c.id.ToString()
            };
            ViewData["type"] = selectList;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Core.Model.News news)
        {
            Core.Controller.NewsController ctr = new Core.Controller.NewsController();
            news.date = DateTime.Now;
            ctr.saveNews(news);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Core.Controller.NewsController ctr = new Core.Controller.NewsController();
            Core.Model.News news = ctr.getNewsById(id);
            List<Core.Model.NewsType> _list = ctr.getNewsType();
            List<SelectListItem> _items = new List<SelectListItem>();
            IEnumerable<SelectListItem> selectList = 
            from c in _list
            select new SelectListItem
            {
    	        Selected = (c.id == news.type),
    	        Text = c.name,
    	        Value = c.id.ToString()
            };
            ViewData["type"]=selectList;
            return View(news);
        }
        [HttpPost]
        public ActionResult Edit(Core.Model.News news)
        {
            Core.Controller.NewsController ctr = new Core.Controller.NewsController();
            news.date = DateTime.Now;
            ctr.saveEditNews(news);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Core.Controller.NewsController ctr = new Core.Controller.NewsController();
            ctr.deleteNews(id);
            return RedirectToAction("index","news");
        }
        public ActionResult Details(int id)
        {
            Core.Controller.NewsController ctr = new Core.Controller.NewsController();
            Core.Model.News news = ctr.getNewsById(id);
            return View(news);
        }
    }
}
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
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            _list = ctr.Get10NewsByPageIndex(1);
            return View(_list);
        }
        public ActionResult Create()
        {
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            List<Core.Model.NewsType> _list = ctr.GetNewsType();
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
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            news.date = DateTime.Now;
            ctr.AddNews(news);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            Core.Model.News news = ctr.GetNewsById(id);
            List<Core.Model.NewsType> _list = ctr.GetNewsType();
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
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            news.date = DateTime.Now;
            ctr.EditNews(news);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            ctr.DeleteNews(id);
            return RedirectToAction("index","news");
        }
        public ActionResult Details(int id)
        {
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            Core.Model.News news = ctr.GetNewsById(id);
            return View(news);
        }
    }
}
using Core.Model;
using Core.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Core.Controller.StaffHandle ctr = new Core.Controller.StaffHandle();
            List<Core.Model.Staff> s = new List<Core.Model.Staff>();
            s = ctr.getAllStaff();
            return View(s);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult NewsId(int id)
        {
            Core.Model.News news = new Core.Model.News();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            news = ctr.GetNewsById(id);
            ctr.IncreaseViewCountNews(id);
            return View(news);
        }
        public PartialViewResult RenderNews()
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            _list = ctr.Get10NewsByPageIndex(1);
            ViewBag.SumPage = (ctr.GetSumNews() / 10) + 1;
            ViewBag.CurrentPage = 1;
            ViewBag.Page = "rendernewspage";
            return PartialView("RenderNews", _list);
        }

        public PartialViewResult RenderNewsPage(int id)
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            _list = ctr.Get10NewsByPageIndex(id);
            ViewBag.SumPage = (ctr.GetSumNews() / 10) + 1;
            ViewBag.CurrentPage = id;
            ViewBag.Page = "rendernewspage";
            return PartialView("RenderNews", _list);
        }

        public ActionResult Cat(int id, int type)
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            _list = ctr.Get10NewsByTypeAndPageIndex(id, type);
            ViewBag.SumPage = (ctr.GetSumNewsByCatalogue(id) / 10) + 1;
            ViewBag.CurrentPage = id;
            ViewBag.Page = "cat";
            return View("RenderNews", _list);

        }

        public ActionResult Search(int id, string keyword)
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            _list = ctr.Get10NewsBySearchAndPageIndex(keyword, id);
            ViewBag.SumPage = (ctr.GetSumNewsBySearch(keyword) / 10) + 1;
            ViewBag.CurrentPage = id;
            ViewBag.Page = "search";
            return View("RenderNews", _list);

        }
        [ChildActionOnly]
        public PartialViewResult LatestNews()
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctl = new Core.Controller.NewsHandle();
            _list = ctl.Get4LastestNews();
            return PartialView("_LatestNews", _list);
        }
        [ChildActionOnly]
        public PartialViewResult TopNews()
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctl = new Core.Controller.NewsHandle();
            _list = ctl.Get4TopNews();
            return PartialView("_TopNews", _list);
        }
    }
}
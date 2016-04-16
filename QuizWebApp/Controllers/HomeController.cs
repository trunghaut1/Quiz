using Core.Model;
using Core.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
        [ChildActionOnly]
        public PartialViewResult Platform()
        {
            NewsHandle newsHandle = new NewsHandle();
            News desktop = newsHandle.GetLastestNewsByType(5);
            News android = newsHandle.GetLastestNewsByType(4);
            
            long? idDesktop = null;
            long? idAndroid = null;
            if (desktop != null) idDesktop = desktop.id;
            if (android != null) idAndroid = android.id;
            ViewBag.idDesktop = idDesktop;
            ViewBag.idAndroid = idAndroid;
            return PartialView("_Platform");
        }
        public ActionResult NewsId(int id)
        {
            Core.Model.News news = new Core.Model.News();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            news = ctr.GetNewsById(id);
            ctr.IncreaseViewCountNews(id);
            List<News> listNews = ctr.Get4LastestNewsByType(news.type);
            ViewData["listNews"] = listNews;
            return View(news);
        }

        public ActionResult RenderNews(int? page)
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            _list = ctr.GetAllNews();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Action = "RenderNews";
            if(!ControllerContext.IsChildAction)
                return View("RenderNews", _list.ToPagedList(pageNumber, pageSize));
            else
                return PartialView("RenderNews", _list.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Cat(int? page, int type)
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            _list = ctr.GetAllNewsByType(type);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Action = "cat";
            return View("RenderNews", _list.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Search(int? page, string keyword)
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsHandle ctr = new Core.Controller.NewsHandle();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Action = "search";
            return View("RenderNews", _list.ToPagedList(pageNumber, pageSize));

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
        [ChildActionOnly]
        public PartialViewResult Staff()
        {
            List<Core.Model.Staff> _list = new List<Core.Model.Staff>();
            Core.Controller.StaffHandle ctl = new Core.Controller.StaffHandle();
            _list = ctl.getAllStaff();
            return PartialView("_Team", _list);
        }
    }
}
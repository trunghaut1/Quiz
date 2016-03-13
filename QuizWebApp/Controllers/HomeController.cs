﻿using System;
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
            return View();
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
        public PartialViewResult LatestNews()
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsController ctl = new Core.Controller.NewsController();
            _list = ctl.get4LatestNews();
            return PartialView("_LatestNews",_list);
        }
        public PartialViewResult TopNews()
        {
            List<Core.Model.News> _list = new List<Core.Model.News>();
            Core.Controller.NewsController ctl = new Core.Controller.NewsController();
            _list = ctl.get4TopNews();
            return PartialView("_TopNews", _list);
        }
    }
}
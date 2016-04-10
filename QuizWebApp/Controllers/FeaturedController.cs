using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizWebApp.Controllers
{
    public class FeaturedController : Controller
    {
        // GET: Featured
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizWebApp.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
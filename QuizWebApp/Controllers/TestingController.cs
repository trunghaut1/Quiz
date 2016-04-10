using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace QuizWebApp.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        [Authorize]
        public ActionResult Index()
        {
            Core.Controller.SubjectHandle ctr = new Core.Controller.SubjectHandle();
            List<Core.Model.Subject> _list = ctr.GetAllSubject();
            IEnumerable<SelectListItem> items = from c in _list
                                                select new SelectListItem
                                                {
                                                    Value = c.SubId,
                                                    Text = c.SubName
                                                };
            ViewData["items"] = items;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string sub = fc["sub"];
            Core.Controller.QuestionHandle ctr = new Core.Controller.QuestionHandle();
            List<Core.Model.Question> _list = ctr.GetQuestionBySubjectNameAndQuantity(sub, 40);
            return View("Loading",_list);
        }
        [Authorize]
        public JsonResult DoMark(List<Core.Model.Question> _list, string timer)
        {
            Core.Controller.AchievementHandle tdctr = new Core.Controller.AchievementHandle();
            Core.Controller.QuestionHandle ctr = new Core.Controller.QuestionHandle();
            Core.Model.History h = new Core.Model.History();
            Core.Model.Info info = new Core.Model.Info();

            var _userid = System.Web.HttpContext.Current.User.Identity.GetUserId();

            int _numanswer = 0;
            int _numcorrect = 0;
            string subId = _list[0].SubId;
            for(int i=0;i<_list.Count;i++)
            {
                Core.Model.Question q = ctr.GetSubjectById(_list[i].Id);
                _list[i].Answer = q.Answer;
                if (_list[i].Traloi != null) _numanswer++;
                if (_list[i].IsCorrect) _numcorrect++;
            }
            //history
            h.UserId = _userid;
            h.NumberAns = _numanswer;
            h.NumberCorrect = _numcorrect;
            h.NumberQuest = _list.Count;
            h.SubId = _list[0].SubId;
            h.DateTime = DateTime.Now;
            //Info
            info.UserId = _userid;
            info.NumAnswer = _numanswer;
            info.NumAnswerTrue = _numcorrect;
            info.SubId = _list[0].SubId;
            info.TimeUse = timer == null ? 0 : int.Parse(timer);
            tdctr.AddHistory(h);
            tdctr.AddInfo(info);
            return Json(_list,JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Loading()
        {
            Core.Controller.SubjectHandle ctr = new Core.Controller.SubjectHandle();
            List<Core.Model.Subject> _list = ctr.GetAllSubject();
            IEnumerable<SelectListItem> items = from c in _list
                                         select new SelectListItem
                                         {
                                             Text = c.SubId,
                                             Value = c.SubName
                                         };
            ViewData["items"] = items;
            return View();
        }
    }
}
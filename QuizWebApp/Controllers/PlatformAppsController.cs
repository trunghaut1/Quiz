using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.Model;

namespace QuizWebApp.Controllers
{
    public class PlatformAppsController : Controller
    {
        private Entities db = new Entities();

        // GET: PlatformApps
        public ActionResult Index()
        {
            return View(db.PlatformApps.ToList());
        }

        // GET: PlatformApps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformApp platformApp = db.PlatformApps.Find(id);
            if (platformApp == null)
            {
                return HttpNotFound();
            }
            return View(platformApp);
        }

        // GET: PlatformApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatformApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title,name,img_link")] PlatformApp platformApp)
        {
            if (ModelState.IsValid)
            {
                db.PlatformApps.Add(platformApp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(platformApp);
        }

        // GET: PlatformApps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformApp platformApp = db.PlatformApps.Find(id);
            if (platformApp == null)
            {
                return HttpNotFound();
            }
            return View(platformApp);
        }

        // POST: PlatformApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,name,img_link")] PlatformApp platformApp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platformApp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platformApp);
        }

        // GET: PlatformApps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformApp platformApp = db.PlatformApps.Find(id);
            if (platformApp == null)
            {
                return HttpNotFound();
            }
            return View(platformApp);
        }

        // POST: PlatformApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatformApp platformApp = db.PlatformApps.Find(id);
            db.PlatformApps.Remove(platformApp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

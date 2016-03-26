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
    public class ReleasesController : Controller
    {
        private Entities db = new Entities();

        // GET: Releases
        public ActionResult Index()
        {
            var releases = db.Releases.Include(r => r.ReleaseType);
            return View(releases.ToList());
        }

        // GET: Releases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            return View(release);
        }

        // GET: Releases/Create
        public ActionResult Create()
        {
            ViewBag.type = new SelectList(db.ReleaseTypes, "id", "name");
            return View();
        }

        // POST: Releases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,type,version,linkDownload,text,date")] Release release)
        {
            if (ModelState.IsValid)
            {
                release.date = DateTime.Now;
                db.Releases.Add(release);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.type = new SelectList(db.ReleaseTypes, "id", "name", release.type);
            return View(release);
        }

        // GET: Releases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            ViewBag.type = new SelectList(db.ReleaseTypes, "id", "name", release.type);
            return View(release);
        }

        // POST: Releases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,type,version,linkDownload,text,date")] Release release)
        {
            if (ModelState.IsValid)
            {
                db.Entry(release).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.type = new SelectList(db.ReleaseTypes, "id", "name", release.type);
            return View(release);
        }

        // GET: Releases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            return View(release);
        }

        // POST: Releases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Release release = db.Releases.Find(id);
            db.Releases.Remove(release);
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

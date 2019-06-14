using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCStat.Models;

namespace WebApplicationMVCStat.Controllers
{
    public class AcademiesController : Controller
    {
        private ModelStatCesiContainer db = new ModelStatCesiContainer();

        // GET: Academies
        public ActionResult Index()
        {
            return View(db.AcademySet.ToList());
        }

        // GET: Academies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = db.AcademySet.Find(id);
            if (academy == null)
            {
                return HttpNotFound();
            }
            return View(academy);
        }

        // GET: Academies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Academies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Area")] Academy academy)
        {
            if (ModelState.IsValid)
            {
                db.AcademySet.Add(academy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academy);
        }

        // GET: Academies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = db.AcademySet.Find(id);
            if (academy == null)
            {
                return HttpNotFound();
            }
            return View(academy);
        }

        // POST: Academies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Area")] Academy academy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academy);
        }

        // GET: Academies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = db.AcademySet.Find(id);
            if (academy == null)
            {
                return HttpNotFound();
            }
            return View(academy);
        }

        // POST: Academies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Academy academy = db.AcademySet.Find(id);
            db.AcademySet.Remove(academy);
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

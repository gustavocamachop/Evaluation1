using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Evaluation.Models;

namespace Evaluation.Controllers
{
    public class GradesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Grades
        public ActionResult Index()
        {
            var grades = db.Grades.Include(g => g.Student);
            return View(grades.ToList());
        }

        // GET: Grades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return HttpNotFound();
            }
            return View(grades);
        }

        // GET: Grades/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Students, "ID", "Name");
            return View();
        }

        // POST: Grades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NID,Subject,Grade,ID,Status")] Grades grades)
        {
            if (ModelState.IsValid)
            {
                db.Grades.Add(grades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Students, "ID", "Name", grades.ID);
            return View(grades);
        }

        // GET: Grades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Students, "ID", "Name", grades.ID);
            return View(grades);
        }

        // POST: Grades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NID,Subject,Grade,ID,Status")] Grades grades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Students, "ID", "Name", grades.ID);
            return View(grades);
        }

        // GET: Grades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return HttpNotFound();
            }
            return View(grades);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grades grades = db.Grades.Find(id);
            db.Grades.Remove(grades);
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

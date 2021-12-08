using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraningCenter.Models;

namespace TraningCenter.Controllers
{
    public class Instr_CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instr_Courses
        public ActionResult Index()
        {
            var instr_Courses = db.Instr_Courses.Include(i => i.courses).Include(i => i.Instractor);
            return View(instr_Courses.ToList());
        }

        // GET: Instr_Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instr_Courses instr_Courses = db.Instr_Courses.Include(a => a.courses).Include(a => a.Instractor).FirstOrDefault(a => a.Id == id);
            if (instr_Courses == null)
            {
                return HttpNotFound();
            }
            return View(instr_Courses);
        }

        // GET: Instr_Courses/Create
        public ActionResult Create()
        {
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name");
            ViewBag.Instractor_Id = new SelectList(db.Instractors, "Instractor_Id", "Instractor_Name");
            return View();
        }

        // POST: Instr_Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Instractor_Id,Course_Id")] Instr_Courses instr_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Instr_Courses.Add(instr_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name", instr_Courses.Course_Id);
            ViewBag.Instractor_Id = new SelectList(db.Instractors, "Instractor_Id", "Instractor_Name", instr_Courses.Instractor_Id);
            return View(instr_Courses);
        }

        // GET: Instr_Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instr_Courses instr_Courses = db.Instr_Courses.Include(a => a.courses).Include(a => a.Instractor).FirstOrDefault(a => a.Id == id);
            if (instr_Courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name", instr_Courses.Course_Id);
            ViewBag.Instractor_Id = new SelectList(db.Instractors, "Instractor_Id", "Instractor_Name", instr_Courses.Instractor_Id);
            return View(instr_Courses);
        }

        // POST: Instr_Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Instractor_Id,Course_Id")] Instr_Courses instr_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instr_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name", instr_Courses.Course_Id);
            ViewBag.Instractor_Id = new SelectList(db.Instractors, "Instractor_Id", "Instractor_Name", instr_Courses.Instractor_Id);
            return View(instr_Courses);
        }

        // GET: Instr_Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instr_Courses instr_Courses = db.Instr_Courses.Find(id);
            if (instr_Courses == null)
            {
                return HttpNotFound();
            }
            return View(instr_Courses);
        }

        // POST: Instr_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instr_Courses instr_Courses = db.Instr_Courses.Find(id);
            db.Instr_Courses.Remove(instr_Courses);
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

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
    public class Student_CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student_Courses
        public ActionResult Index()
        {
            var student_Courses = db.Student_Courses.Include(s => s.courses).Include(s => s.student);
            return View(student_Courses.ToList());
        }

        // GET: Student_Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Courses student_Courses = db.Student_Courses.Include(x => x.student).Include(x => x.courses).FirstOrDefault(a => a.Id == id);
            if (student_Courses == null)
            {
                return HttpNotFound();
            }
            return View(student_Courses);
        }

        // GET: Student_Courses/Create
        public ActionResult Create()
        {
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name");
            ViewBag.Student_id = new SelectList(db.Students, "Student_id", "Student_Name");
            return View();
        }

        // POST: Student_Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_id,Course_Id")] Student_Courses student_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Student_Courses.Add(student_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name", student_Courses.Course_Id);
            ViewBag.Student_id = new SelectList(db.Students, "Student_id", "Student_Name", student_Courses.Student_id);
            return View(student_Courses);
        }

        // GET: Student_Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Courses student_Courses = db.Student_Courses.Include(a => a.student).Include(a => a.courses).FirstOrDefault(a => a.Id == id);
            if (student_Courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name", student_Courses.Course_Id);
            ViewBag.Student_id = new SelectList(db.Students, "Student_id", "Student_Name", student_Courses.Student_id);
            return View(student_Courses);
        }

        // POST: Student_Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_id,Course_Id")] Student_Courses student_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course_name", student_Courses.Course_Id);
            ViewBag.Student_id = new SelectList(db.Students, "Student_id", "Student_Name", student_Courses.Student_id);
            return View(student_Courses);
        }

        // GET: Student_Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Courses student_Courses = db.Student_Courses.Find(id);
            if (student_Courses == null)
            {
                return HttpNotFound();
            }
            return View(student_Courses);
        }

        // POST: Student_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Courses student_Courses = db.Student_Courses.Find(id);
            db.Student_Courses.Remove(student_Courses);
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

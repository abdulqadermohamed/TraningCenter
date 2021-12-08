
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
    public class InstractorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instractors
        public ActionResult Index()
        {
            return View(db.Instractors.ToList());
        }

        // GET: Instractors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instractor instractor = db.Instractors.Find(id);
            if (instractor == null)
            {
                return HttpNotFound();
            }
            return View(instractor);
        }

        // GET: Instractors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instractors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Instractor_Id,Instractor_Name")] Instractor instractor)
        {
            if (ModelState.IsValid)
            {
                db.Instractors.Add(instractor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instractor);
        }

        // GET: Instractors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instractor instractor = db.Instractors.Find(id);
            if (instractor == null)
            {
                return HttpNotFound();
            }
            return View(instractor);
        }

        // POST: Instractors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Instractor_Id,Instractor_Name")] Instractor instractor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instractor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instractor);
        }

        // GET: Instractors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instractor instractor = db.Instractors.Find(id);
            if (instractor == null)
            {
                return HttpNotFound();
            }
            return View(instractor);
        }

        // POST: Instractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instractor instractor = db.Instractors.Find(id);
            db.Instractors.Remove(instractor);
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

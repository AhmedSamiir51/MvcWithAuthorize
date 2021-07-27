using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcWithLogin.Models;

namespace MvcWithLogin.Controllers
{
    [Authorize(Roles = " Admin , Istructor")]
    public class Dep_CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dep_Courses
        [AllowAnonymous]

        public ActionResult Index()
        {
            var dep_Courses = db.Dep_Courses.Include(d => d.Courses).Include(d => d.Department);
            return View(dep_Courses.ToList());
        }

        // GET: Dep_Courses/Details/5
        [AllowAnonymous]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dep_Courses dep_Courses = db.Dep_Courses.Where(e => e.Courses_id == id).First();
            if (dep_Courses == null)
            {
                return HttpNotFound();
            }
            return View(dep_Courses);
        }

        // GET: Dep_Courses/Create
        public ActionResult Create()
        {
            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name");
            ViewBag.Dep_id = new SelectList(db.Departments, "ID", "Name");
            return View();
        }

        // POST: Dep_Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dep_id,Courses_id")] Dep_Courses dep_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Dep_Courses.Add(dep_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name", dep_Courses.Courses_id);
            ViewBag.Dep_id = new SelectList(db.Departments, "ID", "Name", dep_Courses.Dep_id);
            return View(dep_Courses);
        }

        // GET: Dep_Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dep_Courses dep_Courses = db.Dep_Courses.Where(e=>e.Courses_id==id).First();
            if (dep_Courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name", dep_Courses.Courses_id);
            ViewBag.Dep_id = new SelectList(db.Departments, "ID", "Name", dep_Courses.Dep_id);
            return View(dep_Courses);
        }

        // POST: Dep_Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dep_id,Courses_id")] Dep_Courses dep_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dep_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name", dep_Courses.Courses_id);
            ViewBag.Dep_id = new SelectList(db.Departments, "ID", "Name", dep_Courses.Dep_id);
            return View(dep_Courses);
        }

        // GET: Dep_Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dep_Courses dep_Courses = db.Dep_Courses.Where(e => e.Courses_id == id).First();
            if (dep_Courses == null)
            {
                return HttpNotFound();
            }
            return View(dep_Courses);
        }

        // POST: Dep_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dep_Courses dep_Courses = db.Dep_Courses.Where(e => e.Courses_id == id).First();
            db.Dep_Courses.Remove(dep_Courses);
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

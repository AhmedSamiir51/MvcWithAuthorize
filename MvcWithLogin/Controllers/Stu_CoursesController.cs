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
    public class Stu_CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stu_Courses
        [AllowAnonymous]

        public ActionResult Index()
        {
            var stu_Courses = db.Stu_Courses.Include(s => s.Courses).Include(s => s.Student);
            return View(stu_Courses.ToList());
        }

        // GET: Stu_Courses/Details/5
        [AllowAnonymous]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stu_Courses stu_Courses = db.Stu_Courses.Find(id);
            if (stu_Courses == null)
            {
                return HttpNotFound();
            }
            return View(stu_Courses);
        }

        // GET: Stu_Courses/Create
        public ActionResult Create()
        {
            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name");
            ViewBag.St_id = new SelectList(db.Students, "ID", "Name");
            return View();
        }

        // POST: Stu_Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "St_id,Courses_id,Grade")] Stu_Courses stu_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Stu_Courses.Add(stu_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name", stu_Courses.Courses_id);
            ViewBag.St_id = new SelectList(db.Students, "ID", "Name", stu_Courses.St_id);
            return View(stu_Courses);
        }

        // GET: Stu_Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stu_Courses stu_Courses = db.Stu_Courses.Find(id);
            if (stu_Courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name", stu_Courses.Courses_id);
            ViewBag.St_id = new SelectList(db.Students, "ID", "Name", stu_Courses.St_id);
            return View(stu_Courses);
        }

        // POST: Stu_Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "St_id,Courses_id,Grade")] Stu_Courses stu_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses_id = new SelectList(db.Courses, "ID", "Name", stu_Courses.Courses_id);
            ViewBag.St_id = new SelectList(db.Students, "ID", "Name", stu_Courses.St_id);
            return View(stu_Courses);
        }

        // GET: Stu_Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stu_Courses stu_Courses = db.Stu_Courses.Find(id);
            if (stu_Courses == null)
            {
                return HttpNotFound();
            }
            return View(stu_Courses);
        }

        // POST: Stu_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stu_Courses stu_Courses = db.Stu_Courses.Find(id);
            db.Stu_Courses.Remove(stu_Courses);
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

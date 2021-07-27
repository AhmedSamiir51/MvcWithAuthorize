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
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Departments
        [AllowAnonymous]

        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        public ActionResult AddCourses(int ID)
        {
            var dept = db.Dep_Courses.Where(e => e.Dep_id == ID).Select(s=>s.Courses).ToList();
            var cour = db.Courses.ToList<Courses>();
            var notcours = cour.Except(dept).ToList<Courses>();
            return View(notcours);
        }
        [HttpPost]
        public ActionResult AddCourses(int ID , int[] courses)
        {
            foreach (var item in courses)
            {
                db.Dep_Courses.Add(new Dep_Courses() { Dep_id = ID, Courses_id = item });
              
                var ahmed = from i in db.Students
                            where i.Dept_id == ID
                            select i;
                foreach (var i in ahmed)
                {
                  db.Stu_Courses.Add(new Stu_Courses() { St_id = i.ID, Courses_id = item , Grade = 1 });
                }

            }

            db.SaveChanges();
            return RedirectToAction("index");
        }



        public ActionResult RemoveCourses(int ID)
        {
            var dept = db.Dep_Courses.Where(e => e.Dep_id == ID).Select(s => s.Courses).ToList();
            
            return View(dept);
        }
        [HttpPost]
        public ActionResult RemoveCourses(int ID, int[] courses)
        {
            foreach (var item in courses)
            {
                var depts = db.Dep_Courses.Where(e => e.Dep_id == ID).First();
                db.Dep_Courses.Remove(depts);
                var ss = db.Stu_Courses.Where(e => e.Student.Dept_id == depts.Dep_id).First();
                db.Stu_Courses.Remove(ss);
            }

            db.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Display(int id )
        {
           
            var sc = db.Dep_Courses.Where(a => a.Dep_id == id).Select(s => s.Courses).ToList();
            SelectList scl = new SelectList(sc,"ID", "Name");
            ViewBag.scl = scl;

            var stud = db.Students.Where(e => e.Dept_id == id).ToList();
            return View(stud);
        }
        [HttpPost]
        public ActionResult Display(int id , int C_ID,  IDictionary<string, int> mydic )
        {

            foreach (var item in mydic)
            {
                var stu =int.Parse(item.Key);
                var Ass = from i in db.Stu_Courses
                          where i.St_id == stu && i.Courses_id == C_ID&&i.Student.Dept_id==id
                          select i;

                foreach (var ss in Ass)
                {
                    ss.Grade = item.Value;
                }

            }
            
            db.SaveChanges();
            return RedirectToAction("index");
        }



        // GET: Departments/Details/5
        [AllowAnonymous]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using todoApp.Models;

namespace todoApp.Controllers
{
    public class Default1Controller : Controller
    {
        private ToDoEntities db = new ToDoEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var todos = db.toDos.Include(t => t.priorityType);
            return View(todos.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            toDo todo = db.toDos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.priorityTypeId = new SelectList(db.priorityTypes, "Id", "PriorityType1");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(toDo todo)
        {
            if (ModelState.IsValid)
            {
                db.toDos.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.priorityTypeId = new SelectList(db.priorityTypes, "Id", "PriorityType1", todo.priorityTypeId);
            return View(todo);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            toDo todo = db.toDos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            ViewBag.priorityTypeId = new SelectList(db.priorityTypes, "Id", "PriorityType1", todo.priorityTypeId);
            return View(todo);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(toDo todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.priorityTypeId = new SelectList(db.priorityTypes, "Id", "PriorityType1", todo.priorityTypeId);
            return View(todo);
        }

        //
        // GET: /Default1/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            toDo todo = db.toDos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            toDo todo = db.toDos.Find(id);
            db.toDos.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
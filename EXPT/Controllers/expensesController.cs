using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EXPT.Models;
using System.ComponentModel.DataAnnotations;

namespace EXPT.Controllers
{
    public class expensesController : Controller
    {
        private exptEntities db = new exptEntities();

        // GET: Expenses
        public ActionResult Index()
        {
            var expenses = db.expenses.Include(e => e.catagory1);
            return View(expenses.ToList());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expens expens = db.expenses.Find(id);
            if (expens == null)
            {
                return HttpNotFound();
            }
            return View(expens);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.Catagory = new SelectList(db.catagories, "ID", "Catagories");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Amount,Catagory,Date")] Expens expens)
        {
            if (ModelState.IsValid)
            {
                db.expenses.Add(expens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Catagory = new SelectList(db.catagories, "ID", "Catagories", expens.Catagory);
            return View(expens);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expens expens = db.expenses.Find(id);
            if (expens == null)
            {
                return HttpNotFound();
            }
            ViewBag.Catagory = new SelectList(db.catagories, "ID", "Catagories", expens.Catagory);
            return View(expens);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Amount,Catagory,Date")] Expens expens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Catagory = new SelectList(db.catagories, "ID", "Catagories", expens.Catagory);
            return View(expens);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expens expens = db.expenses.Find(id);
            if (expens == null)
            {
                return HttpNotFound();
            }
            return View(expens);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expens expens = db.expenses.Find(id);
            db.expenses.Remove(expens);
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

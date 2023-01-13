using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using EXPT.Models;
using System.Net;

namespace EXPT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.catlist = getCatagories();
            dy.explist = getExpenses();
            return View(dy);
        }

        //public ActionResult Addbycat()
        //{
        //    dynamic dy = new ExpandoObject();
        //    dy.catlist = getCatagories();
        //    dy.explist = getExpenses();
        //    return View(dy);
        //}

        //public ActionResult Addbycat(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    dynamic dy = new ExpandoObject();
        //    dy.catlist = getCatagories();
        //    dy.explist = getExpenses();
        //    if (dy.catlist == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dy);
        //}

        public List<catagory> getCatagories()
        {
            exptEntities cd = new exptEntities();
            List<catagory> Lcatagories = cd.catagories.ToList();
            return Lcatagories;
        }

        public List<Expens> getExpenses()
        {
            exptEntities cd = new exptEntities();
            List<Expens> Lexpenses = cd.expenses.ToList();
            return Lexpenses;
        }
    }
}
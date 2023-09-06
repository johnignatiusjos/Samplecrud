using Samplecrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Samplecrud.Controllers
{
    public class CrudsampletController : Controller
    {
        // GET: Crudsamplet
        PersonEntities db = new PersonEntities();
        public ActionResult Index()
        {
            var result = db.Roles.ToList();
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = db.Roles.Find(id);
            return View(result);
        }

        public ActionResult Edits(Role ID)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(ID);
        }
        public ActionResult Details (int id)
        {
            var result = db.Roles.Find(id);
            return View(result);
        }
        public ActionResult Delete(int id)
        {
            var result = db.Roles.Find(id);
            db.Roles.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Creates(Role result)
        {
            db.Roles.Add(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Save(Role result)
        {
            db.Roles.AddOrUpdate(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    } 
}

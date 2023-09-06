using Samplecrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Samplecrud.Controllers
{
    public class LogController : Controller
    {
        PersonEntities db = new PersonEntities();


        // GET: Log  LogenEntities
        public ActionResult Index()
        {
            return View("Logview");
        }
        public ActionResult Llogin(userpass lpara)
        {


            var result = db.userpasses.Where(x => x.Username == lpara.Username && x.Password == lpara.Password).SingleOrDefault();
            if (result==null)
            {
                return RedirectToAction("Index");
            }

            Session["role_id"] = result.Roleid;
            Session["userid"] = result.ID;
            return RedirectToAction("Index", "Crudsamplet");
            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }



        public ActionResult Addsup()
        {
            return View("Addsup");
        }
    }
}
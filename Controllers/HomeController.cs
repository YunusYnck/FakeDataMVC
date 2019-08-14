using FakeData_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeData_MVC.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
       
            return View();
        }
        public ActionResult Listele()
        {
            var model = db.Personeller.ToList();
            return View(model);

        }
    }
}

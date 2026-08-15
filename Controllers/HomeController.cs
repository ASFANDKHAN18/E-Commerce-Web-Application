using byhands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace byhands.Controllers
{
    public class HomeController : Controller
    {
        byhandsEntities db = new byhandsEntities();
        public ActionResult Index()
        {
            var bouquet = db.Bouquets.Take(8).ToList();
            return View(bouquet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
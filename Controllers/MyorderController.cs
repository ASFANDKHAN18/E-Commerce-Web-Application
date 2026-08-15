using byhands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace byhands.Controllers
{
    public class MyorderController : Controller
    {
        byhandsEntities db = new byhandsEntities();
        public ActionResult Myorder()
        {
            if(Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userid =Convert.ToInt32(Session["UserId"]);
            var order = db.Orders.Where(o=>o.UserId == userid).OrderByDescending(o=>o.UserId).ToList();
            return View(order);
        }
        public ActionResult Orderdetail(int id) { 


            var order = db.Orders.Include("Recipients").FirstOrDefault(o => o.OrderId == id);

            if(order == null)
            {
                return RedirectToAction("Myorder");
            }
        
        return View(order);
        
        
        }
    }
}
using byhands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace byhands.Controllers
{
    public class AccountController : Controller
    {
        byhandsEntities db = new byhandsEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string passwd)
        {
            var user = db.Users.FirstOrDefault(x=> x.Email == email && x.Password == passwd);
            if (user == null) {
                ViewBag.error = "invalid email or password";
                return View();
            
            }
            Session["UserId"] = user.UserId;
            Session["Username"] = user.Username;


            return RedirectToAction("Index","Cart");
        }




        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User u)
        {
            if (db.Users.Any(x => x.Email == u.Email))
            {
                ViewBag.Error = "Email already exists";
                return View();
            }

            db.Users.Add(u);
            db.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
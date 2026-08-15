using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using byhands.Models;

namespace byhands.Controllers
{
    public class CartController : Controller
    {
        byhandsEntities db = new byhandsEntities();
        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            var product = db.Bouquets.FirstOrDefault(b => b.BouquetId == id);
            if (product == null)
                return RedirectToAction("Index", "Product");

            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(c => c.BouquetId == id);

            if (existingItem != null)
                existingItem.Quantity += 1;
            else
                cart.Add(new CartItem
                {
                    BouquetId = product.BouquetId,
                    BouquetName = product.BouquetName,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });

            Session["Cart"] = cart;

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id) {

            var cart = Session["Cart"] as List<CartItem>;
            var item = cart.FirstOrDefault(c=> c.BouquetId ==id);

            cart.Remove(item);
            return RedirectToAction("Index");   
        
        }

        public ActionResult Increase(int id)
        {
            var cart = Session["Cart"] as List<CartItem>;
            var item = cart.FirstOrDefault(c => c.BouquetId == id);
            item.Quantity += 1;

            return RedirectToAction("Index");
        }


        public ActionResult Decrease(int id)
        {
            var cart = Session["Cart"] as List<CartItem>;
            var item = cart.FirstOrDefault(c => c.BouquetId == id);

            if (item.Quantity > 1)
                item.Quantity -= 1;

            return RedirectToAction("Index");
        }


    }
}
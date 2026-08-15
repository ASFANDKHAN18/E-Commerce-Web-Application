using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using byhands.Models;
using System.Data.Entity;

namespace byhands.Controllers
{
    public class CheckoutController : Controller
    {
        byhandsEntities db = new byhandsEntities();
     
        public ActionResult Index()
        {
            if (Session["UserId"]== null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = Session["Cart"] as List<CartItem>;

            if (cart == null ||!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }
            return View(cart);
            
        }

        [HttpPost]
        public ActionResult PlaceOrder(string RecipientName, string Address, string Phone , DateTime DeliveryDate) 
        {
            int userid = (int)Session["UserId"];
            var cart = Session["Cart"] as List<CartItem>;

            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }
            decimal shippingcost = 259;
            Order order = new Order()
            {
                UserId = userid,
                OrderDate = DateTime.Now,
                TotalAmount = cart.Sum(x => x.Total)+shippingcost,
                Status = "Pending"
            };

            db.Orders.Add(order);
            db.SaveChanges();

            Recipient rec = new Recipient()
            {
                OrderId=order.OrderId,
                RecipientName=RecipientName,
                Address=Address,
                Phone=Phone,
                DeliveryDate=DeliveryDate
               

            };
            db.Recipients.Add(rec);

            foreach (var item in cart)
            {

                OrderDetail od = new OrderDetail()
                {

                    OrderId = order.OrderId,
                    BouquetId =item.BouquetId,
                    Quantity = item.Quantity,
                    Price = item.Price

                };
                db.OrderDetails.Add(od);
            }
            db.SaveChanges();
            Session["Cart"] = null;

            return RedirectToAction("Success", new { id = order.OrderId });

        }
        public ActionResult Success()
        {
            

            return View();
        }
    }
}
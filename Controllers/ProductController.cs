using byhands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace byhands.Controllers
{
    public class ProductController : Controller
    {
        byhandsEntities db = new byhandsEntities();
        public ActionResult Index(int? occasionid)
        {
            var bouquet = db.Bouquets.AsQueryable();

            if(occasionid!= null)
            {
                bouquet = bouquet.Where(b => b.OccasionId == occasionid);
            }

            return View(bouquet.ToList());
        }

        public PartialViewResult Categories()
        {
            var cat=db.Occasions.ToList();
            return PartialView(cat);
        }
        public PartialViewResult BestSellers()
        {
            
            var products = db.Bouquets
                             .OrderByDescending(b => b.Price)
                             .Take(4)
                             .ToList();

            return PartialView(products);
        }


        public ActionResult ProductDetail(int id )
        {
            var product = db.Bouquets.FirstOrDefault(b=> b.BouquetId == id);

            if (product == null) { 
            
            HttpNotFound();
            }
            return View(product);
        }


     

    }
}
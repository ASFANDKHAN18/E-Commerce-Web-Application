using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace byhands.Models
{
    public class CartItem
    {
        public int BouquetId { get; set; }
        public string BouquetName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total
        {
            get { return Price * Quantity; }
        }
    }
}

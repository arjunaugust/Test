using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Entities
{
    public class ProductOffers
    {
        public List<ProductCheckout> CheckoutItems { get; set; }

        public double TotalPrice { get; set; }
    }
}

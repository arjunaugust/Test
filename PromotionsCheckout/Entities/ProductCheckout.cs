using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Entities
{
    public class ProductCheckout
    {
        public string ProductCode { get; set; }

        public bool InOffer { get; set; }

        public int Quantity { get; set; }

        public double DefaultPrice { get; set; }

        public double FinalPrice { get; set; }

        public bool IsValid { get; set; }
    }
}

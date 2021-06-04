using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Promotions
    {
        public int PromotionId { get; set; }

        public string PromotionType { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; }

        public double PromotionPrice { get; set; }
    }
}

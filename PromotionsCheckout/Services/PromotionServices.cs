using PromotionsCheckout.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Services
{
    public class PromotionServices : Interfaces.IPromotionService
    {
        public ProductOffers ApplyProductPromotion(List<ProductCheckout> checkoutProductList, List<Promotions> promotions)
        {

            ProductOffers productOffers = new ProductOffers();

            List<Interfaces.IPromotionStrategy> strategies = new List<Interfaces.IPromotionStrategy>();

            
            throw new NotImplementedException();
        }
    }
}

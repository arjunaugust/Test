using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Interfaces
{
    public interface IPromotionService
    {
        Entities.ProductOffers ApplyProductPromotion(List<Entities.ProductCheckout> checkoutProductList, List<Entities.Promotions> promotions);
    }
}

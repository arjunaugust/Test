using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Interfaces
{
    public interface IPromotionStrategy
    {
        bool IsExecute(Entities.ProductCheckout proudctCheckout, List<Entities.Promotions> promotions);

        double CalculcateFinalProductProce(List<Entities.ProductCheckout> checkoutLists);

    }
}

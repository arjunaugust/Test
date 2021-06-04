using PromotionsCheckout.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Services.PromotionStrategiesServices
{
    public class AdditionalOffer : Interfaces.IPromotionStrategy
    {
        private Promotions appliedPromotion;
        private ProductCheckout productCheckout;

        public AdditionalOffer()
        {
            appliedPromotion = new Promotions();
            productCheckout = new ProductCheckout();
        }

        public double CalculcateFinalProductPrice(List<ProductCheckout> checkoutLists)
        {
            double finalPrice = 0;
            try
            {
                int totalEligibleItems = productCheckout.Quantity / appliedPromotion.Quantity;

                int remainingItems = productCheckout.Quantity % appliedPromotion.Quantity;
                finalPrice = appliedPromotion.PromotionPrice * totalEligibleItems + remainingItems * (productCheckout.DefaultPrice);

            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Error in AdditionalItemOffer :" + ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in AdditionalItemOffer :" + e.Message);
            }

            return finalPrice;

        }

        public bool IsExecute(ProductCheckout proudctCheckout, List<Promotions> promotions)
        {
            throw new NotImplementedException();
        }
    }
}

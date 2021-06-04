using PromotionsCheckout.Entities;
using PromotionsCheckout.Services.PromotionStrategiesServices;
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
            strategies.Add(new AdditionalOffer());
            strategies.Add(new ComboOffer());

            try
            {
                foreach (ProductCheckout item in checkoutProductList)
                {
                    if(item.Quantity > 0)
                    {
                        foreach (var strategy in strategies)
                        {
                            if(strategy.IsExecute(item,promotions))
                            {
                                item.InOffer = true;
                                item.FinalPrice = strategy.CalculcateFinalProductPrice(checkoutProductList);
                                productOffers.TotalPrice += item.FinalPrice;
                                break;
                            }
                        }
                    }
                }

                productOffers.CheckoutItems = checkoutProductList;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error during applied offer in Promotion strategy: {ex.Message}");
            }
            return productOffers;
        }
    }
}

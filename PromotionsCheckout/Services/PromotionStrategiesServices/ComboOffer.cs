using PromotionsCheckout.Entities;
using PromotionsCheckout.Helper;
using PromotionsCheckout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionsCheckout.Services.PromotionStrategiesServices
{
    public class ComboOffer : IPromotionStrategy
    {
        Entities.Promotions appliedPromotion;
        Entities.ProductCheckout latestProductCheckout;
        List<ProductCheckout> productsCheckoutList;
        public double CalculcateFinalProductPrice(List<ProductCheckout> checkoutLists)
        {
            productsCheckoutList = new List<ProductCheckout>();
            double finalPrice = 0;
            try
            {
                string[] arrStr = appliedPromotion.ProductCode.Split(";").ToArray();
                foreach (ProductCheckout product in checkoutLists)
                {
                    if(arrStr.Contains(product.ProductCode))
                    {
                        productsCheckoutList.Add(product);
                        product.IsValid = true;
                    }
                }

                int firstQuantity = 0;
                int secondQuantity = 0;
                if(productsCheckoutList.Count > 1)
                {
                    firstQuantity = productsCheckoutList.FirstOrDefault().Quantity;
                    
                }

                if (productsCheckoutList.Count > 2)
                {
                    secondQuantity = productsCheckoutList[1].Quantity;
                }

                if (firstQuantity == 0 || secondQuantity == 0)
                {
                    return latestProductCheckout.DefaultPrice;

                }

                if (firstQuantity == secondQuantity)
                {
                    finalPrice = appliedPromotion.PromotionPrice * firstQuantity;
                }
                else if (firstQuantity > secondQuantity)
                {
                    int additionalItems = secondQuantity - secondQuantity;
                    finalPrice = (latestProductCheckout.DefaultPrice * additionalItems) + (appliedPromotion.PromotionPrice * secondQuantity);
                }
                else if (firstQuantity < secondQuantity)
                {
                    int additionalItems = secondQuantity - firstQuantity;
                    finalPrice = (latestProductCheckout.DefaultPrice * additionalItems) + (appliedPromotion.PromotionPrice * firstQuantity);
                }


            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Error in ComboOffer :" + ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in ComboOffer :" + e.Message);
            }
            return finalPrice;
        }

        public bool IsExecute(ProductCheckout proudctCheckout, List<Promotions> promotions)
        {
            bool isSuccess = false;
            try
            {
                latestProductCheckout = proudctCheckout;
                appliedPromotion = promotions.Where(x => x.ProductCode.Split(';').Contains(proudctCheckout.ProductCode)).FirstOrDefault();
                if (appliedPromotion != null && !proudctCheckout.IsValid
                    && appliedPromotion.PromotionType == PromotionType.Combo.ToString())
                {
                    isSuccess =  true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error in ComboOffer :" + e.Message);
            }
            

            return isSuccess;
        }
    }
}

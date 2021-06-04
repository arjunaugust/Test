using NUnit.Framework;
using PromotionsCheckout.Entities;
using PromotionsCheckout.Interfaces;
using PromotionsCheckout.Services;
using System.Collections.Generic;

namespace PromotionsCheckout.Test
{
    public class PromotionServiceTest
    {
        List<Promotions> promotions;
        IPromotionService promotionService;

        [SetUp]

        public void Setup()
        {
            promotionService = new PromotionServices();
            promotions = new List<Promotions>()
                {
                    new Promotions() { PromotionType = "Single", ProductCode = "A", PromotionPrice = 130, Quantity = 3 },
                    new Promotions() { PromotionType = "Single", ProductCode = "B", PromotionPrice = 45, Quantity = 2 }
                };

        }

        /// <summary>
        /// Scenario A
        /// 1* A =50
        /// 1* B =30
        /// 1* C =20
        /// </summary>
        [Test]
        public void WithoutOfferTest()
        {
            List<ProductCheckout> cart = new List<ProductCheckout>()
            {
                new ProductCheckout(){ProductCode ="A", Quantity = 1, DefaultPrice = 50},
                new ProductCheckout(){ProductCode ="B", Quantity = 1, DefaultPrice = 30},
                new ProductCheckout(){ProductCode ="C", Quantity = 1, DefaultPrice = 20},
            };

            double expectedValue = 80;
            double actualValue = promotionService.ApplyProductPromotion(cart, promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
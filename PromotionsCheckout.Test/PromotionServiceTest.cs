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
                    new Promotions() { PromotionType = "Single", ProductCode = "B", PromotionPrice = 45, Quantity = 2 },
                    new Promotions() { PromotionType = "Combo", ProductCode = "C;D", PromotionPrice = 30, Quantity = 3 } 
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

            double expectedValue = 100;
            double actualValue = promotionService.ApplyProductPromotion(cart, promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }


        /// <summary>
        /// Scenario B
        /// 5 * A =130 + 2*50
        /// 5 * B =45 + 45 + 30
        /// 1 * C =28
        //Total = 370 
        /// </summary>
        [Test]
        public void TwoOfferSingle_Test()
        {
            List<ProductCheckout> orderCart = new List<ProductCheckout>() 
            { 
                new ProductCheckout() { ProductCode = "A", Quantity = 5, DefaultPrice = 50 },
                new ProductCheckout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 }, 
                new ProductCheckout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 } };
            double expectedValue = 370;
            double actualValue = promotionService.ApplyProductPromotion(
                orderCart,
                promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        /// Scenario C
        /// 3* A =130
        /// 5* B =45 + 45 + 1 * 30
        /// 1* C =-
        /// 1* D =30
        /// </summary>
        [Test]
        public void TwoOffer_ComboTest()
        {
            List<ProductCheckout> orderCart = new List<ProductCheckout>()
            { new ProductCheckout() { ProductCode = "A", Quantity = 3, DefaultPrice = 50 },
                new ProductCheckout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 },
                new ProductCheckout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 },
                new ProductCheckout() { ProductCode = "D", Quantity = 1, DefaultPrice = 15 } };
            double expectedValue = 270;
            double actualValue = promotionService.ApplyProductPromotion(orderCart, promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
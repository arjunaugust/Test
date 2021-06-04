using NUnit.Framework;
using PromotionsCheckout.Entities;
using PromotionsCheckout.Interfaces;
using PromotionsCheckout.Services.PromotionStrategiesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionsCheckout.Test
{
    public class ComboOfferTest
    {
        List<Promotions> promotions;
        IPromotionStrategy promotionStrategy;
        List<ProductCheckout> productWithOffer;
        List<ProductCheckout> productWithoutOffer;

        [SetUp]
        public void Setup()
        {
            promotionStrategy = new ComboOffer();
            productWithoutOffer = new List<ProductCheckout>() { new ProductCheckout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 } };
            productWithOffer = new List<ProductCheckout>() { new ProductCheckout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 },
                new ProductCheckout() { ProductCode = "D", Quantity = 1, DefaultPrice = 15 } };
            promotions = new List<Promotions>() 
            { 
                new Promotions() { PromotionType = "Single", ProductCode = "A", PromotionPrice = 130, Quantity = 3 },
                new Promotions() { PromotionType = "Single", ProductCode = "B", PromotionPrice = 45, Quantity = 2 },
                new Promotions() { PromotionType = "Combo", ProductCode = "C;D", PromotionPrice = 30, Quantity = 3 } 
            };
        }

        [Test]
        public void ComboOffer_WithOffer()
        {
            double expectedValue = 20;
            bool canExecute =promotionStrategy.IsExecute(productWithOffer.FirstOrDefault(), promotions);
            if (canExecute)
            {
                double actualValue = promotionStrategy.CalculcateFinalProductPrice(productWithOffer);
                Assert.AreEqual(expectedValue, actualValue);
            }

        }

        [Test]
        public void Scenario_ComboOffer_WithoutOffer()
        {
            double expectedValue = 20;
            bool canExecute = promotionStrategy.IsExecute(productWithoutOffer.FirstOrDefault(), promotions);
            if (canExecute)
            {
                double actualValue = promotionStrategy.CalculcateFinalProductPrice(productWithoutOffer);
                Assert.AreEqual(expectedValue, actualValue);
            }

        }
    }
}

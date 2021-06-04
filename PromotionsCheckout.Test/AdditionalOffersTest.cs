using NUnit.Framework;
using PromotionsCheckout.Entities;
using PromotionsCheckout.Interfaces;
using PromotionsCheckout.Services.PromotionStrategiesServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionsCheckout.Test
{
    public class AdditionalOffersTest
    {
        List<Promotions> _promotions;
        ProductCheckout _productWithOffer;
        ProductCheckout _productWithoutOffer;
        ProductCheckout _productWithOfferExtra;
        IPromotionStrategy _promotionStrategy;

        [SetUp]
        public void Setup()
        {
            _promotionStrategy = new AdditionalOffer();
            _productWithOffer = new ProductCheckout() { ProductCode = "A", Quantity = 3, DefaultPrice = 50 };
            _productWithOfferExtra = new ProductCheckout() { ProductCode = "A", Quantity = 4, DefaultPrice = 50 };
            _productWithoutOffer = new ProductCheckout() { ProductCode = "A", Quantity = 2, DefaultPrice = 50 };
            _promotions = new List<Promotions>() {
                new Promotions() { PromotionType = "Single", ProductCode = "A", PromotionPrice = 130, Quantity = 3 },
                new Promotions() { PromotionType = "Single", ProductCode = "B", PromotionPrice = 45, Quantity = 2 },
                new Promotions() { PromotionType = "Combo", ProductCode = "C;D", PromotionPrice = 30, Quantity = 3 } };
        }


        [Test]
        public void AdditionalItemOffer_WithOffer()
        {
            List<ProductCheckout> cart = new List<ProductCheckout>();
            cart.Add(_productWithOffer);
            double expectedValue = 130;
            bool canExecute = _promotionStrategy.IsExecute(_productWithOffer, _promotions);
            if (canExecute)
            {
                double actualValue = _promotionStrategy.CalculcateFinalProductPrice(cart);
                Assert.AreEqual(expectedValue, actualValue);
            }

        }

        [Test]
        public void AdditionalItemOffer_WithOffer_ExtraItems()
        {
            List<ProductCheckout> cart = new List<ProductCheckout>();
            cart.Add(_productWithOfferExtra);
            double expectedValue = 180;
            bool canExecute = _promotionStrategy.IsExecute(_productWithOfferExtra, _promotions);
            if (canExecute)
            {
                double actualValue = _promotionStrategy.CalculcateFinalProductPrice(cart);
                Assert.AreEqual(expectedValue, actualValue);
            }

        }
        [Test]
        public void AdditionalItemOffer_WithoutOffer()
        {
            List<ProductCheckout> cart = new List<ProductCheckout>();
            cart.Add(_productWithoutOffer);
            double expectedValue = 100;
            bool canExecute = _promotionStrategy.IsExecute(_productWithoutOffer, _promotions);
            if (canExecute)
            {
                double actualValue = _promotionStrategy.CalculcateFinalProductPrice(cart);
                Assert.AreEqual(expectedValue, actualValue);
            }

        }

    }
}

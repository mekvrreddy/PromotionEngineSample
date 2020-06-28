using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineSample;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ApplyNoPromotion()
        {
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("B") });
            Assert.AreEqual(130, PromotionManager.GetFinalPrice(order));
        }

        [TestMethod]
        public void ApplySinglePromotionOnProductA()
        {
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A") });
            Assert.AreEqual(260, PromotionManager.GetFinalPrice(order));
        }

        [TestMethod]
        public void ApplySinglePromotionOnProductB()
        {
            Order order = new Order(1, new List<Product>() { new Product("b"), new Product("b"), new Product("B"), new Product("B") });
            Assert.AreEqual(90, PromotionManager.GetFinalPrice(order));
        }

        [TestMethod]
        public void ApplySinglePromotionOnProductCandD()
        {
            Order order = new Order(1, new List<Product>() { new Product("C"), new Product("D") });
            Assert.AreEqual(30, PromotionManager.GetFinalPrice(order));
        }

        [TestMethod]
        public void ApplyMoreThanOnePromotionsOnProductBandCandD()
        {
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });
            Assert.AreEqual(175, PromotionManager.GetFinalPrice(order));
        }

        [TestMethod]
        public void ApplyMoreThanOnePromotionsOnAllProducts()
        {
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });
            Assert.AreEqual(205, PromotionManager.GetFinalPrice(order));
        }


        [TestMethod]
        public void ApplyPercentagePromotionsOnProductCandD()
        {
            Dictionary<Product, int> promtion1products = new Dictionary<Product, int>();
            promtion1products.Add(new Product("C"), 1);
            promtion1products.Add(new Product("D"), 1);

            List<Promotion> promotions = new List<Promotion>(){
                                                                new Promotion(1, promtion1products, 0.20M, DateTime.Now.AddDays(-10),false,null),
                                                              };

            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("C"), new Product("D") });

            Assert.AreEqual(128, PromotionManager.GetFinalPrice(order,promotions));
        }
    }
}

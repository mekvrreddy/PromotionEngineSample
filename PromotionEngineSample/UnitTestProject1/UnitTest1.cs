using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineSample;
using System.Collections.Generic;

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
    }
}

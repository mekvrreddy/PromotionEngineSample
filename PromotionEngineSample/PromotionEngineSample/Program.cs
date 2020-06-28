using System.Collections.Generic;
using System.Linq;

namespace PromotionEngineSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "Scenario A"
            Order orderA = new Order(1, new List<Product>() { new Product("A"), new Product("B"), new Product("C") });
            decimal finalPrice = PromotionManager.GetFinalPrice(orderA);
            #endregion

            #region "Scenario 5A, 5B C"
            Order order5A5B1C = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"),
                                                              new Product("A"), new Product("A"), new Product("B"),
                                                              new Product("B"), new Product("B"), new Product("B"),
                                                              new Product("B"), new Product("C")
                                                              });
            decimal finalPrice2 = PromotionManager.GetFinalPrice(order5A5B1C);
            #endregion

            #region "Scenario 3A, 5B, 1C and 1D"
            Order order3A5B1C1D = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"),
                                                              new Product("B"), new Product("B"), new Product("B"),
                                                              new Product("B"), new Product("B"), new Product("C"),
                                                              new Product("D")
                                                              });
            decimal finalPrice3 = PromotionManager.GetFinalPrice(order3A5B1C1D);
            #endregion
        }

    }
}

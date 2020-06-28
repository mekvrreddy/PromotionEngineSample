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
            decimal finalPrice = GetFinalPrice(orderA);
            #endregion

            #region "Scenario 5A, 5B C"
            Order order5A5B1C = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"),
                                                              new Product("A"), new Product("A"), new Product("B"),
                                                              new Product("B"), new Product("B"), new Product("B"),
                                                              new Product("B"), new Product("C")
                                                              });
            decimal finalPrice2 = GetFinalPrice(order5A5B1C);
            #endregion
        }

        public static decimal GetFinalPrice(Order order)
        {
            List<decimal> rebateprices = PromotionManager.GetActivePromotions()
                    .Select(promo => PromotionManager.GetTotalRebatePrice(order, promo))
                    .ToList();
            decimal origprice = order.Products.Sum(x => x.UnitPrice);
            decimal rebateprice = rebateprices.Sum();
            return origprice - rebateprice;
        }

    }
}

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
        }

        public static decimal GetFinalPrice(Order order)
        {
            List<decimal> promoprices = PromotionManager.GetActivePromotions()
                    .Select(promo => PromotionManager.GetTotalPrice(order, promo))
                    .ToList();
            decimal origprice = order.Products.Sum(x => x.UnitPrice);
            decimal promoprice = promoprices.Sum();
            return origprice - promoprice;
        }

    }
}

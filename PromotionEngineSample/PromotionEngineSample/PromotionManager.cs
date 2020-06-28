using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngineSample
{
    public class PromotionManager
    {

        public static decimal GetFinalPrice(Order order)
        {
            List<decimal> rebateprices = PromotionManager.GetActivePromotions()
                    .Select(promo => PromotionManager.GetTotalRebatePrice(order, promo))
                    .ToList();
            decimal origprice = order.Products.Sum(x => x.UnitPrice);
            decimal rebateprice = rebateprices.Sum();
            return origprice - rebateprice;
        }

        private static List<Promotion> GetActivePromotions()
        {
            Dictionary<Product, int> promtion1products = new Dictionary<Product, int>();
            promtion1products.Add(new Product("A"), 3);
            Dictionary<Product, int> promtion2products = new Dictionary<Product, int>();
            promtion2products.Add(new Product("B"), 2);
            Dictionary<Product, int> promtion3products = new Dictionary<Product, int>();
            promtion3products.Add(new Product("C"), 1);
            promtion3products.Add(new Product("D"), 1);

            List<Promotion> promotions = new List<Promotion>(){
                                                                new Promotion(1, promtion1products, 130, DateTime.Now.AddDays(-10),true,null),
                                                                new Promotion(2, promtion2products, 45, DateTime.Now.AddDays(-10),true,null),
                                                                new Promotion(3, promtion3products, 30, DateTime.Now.AddDays(-10),true,null)
                                                              };

            return promotions;
        }

        public static decimal GetTotalRebatePrice(Order ord, Promotion promotion)
        {
            decimal rebatePrice = 0M;

            //get count of promoted products
            var orderpromotionproductscounut = ord.Products
                .GroupBy(x => x.SKUId)
                .Where(grp => promotion.ActivationDate <= DateTime.Now &&
                              (promotion.ObsoleteDate is null || (promotion.ObsoleteDate != null && promotion.ObsoleteDate >= DateTime.Now)) &&
                              promotion.Products.Any(y => grp.Key == ((Product)y.Key).SKUId && grp.Count() >= y.Value))
                .Select(grp => grp.Count())
                .Sum();

            //get count of promoted products from promotion
            int promotionproductcount = promotion.Products.Sum(kvp => kvp.Value);
            //get promotion total price value of all products
            decimal promotionallProductsSum = promotion.Products.Sum(kvp => kvp.Value * ((Product)kvp.Key).UnitPrice);
            while (orderpromotionproductscounut >= promotionproductcount)
            {
                //checking Promotion Type
                if (promotion.IsFixedPrice)
                {
                    //fixed Price sceanrio 
                    rebatePrice += promotionallProductsSum - promotion.PromoPrice;
                }
                else
                {
                    //percentage of X of total value of promotion 
                    rebatePrice += (promotion.PromoPrice) * promotionallProductsSum;
                }
                orderpromotionproductscounut -= promotionproductcount;
            }

            return rebatePrice;
        }
    }
}

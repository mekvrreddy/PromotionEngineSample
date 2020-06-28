using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineSample
{
    class PromotionManager
    {
        public static decimal GetTotalPrice(Order ord, Promotion promotion)
        {
            decimal promoPrice = 0M;

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
                    promoPrice += promotion.PromoPrice;
                }
                else
                {
                    //percentage of X of total value of promotion 
                    promoPrice += (promotion.PromoPrice) * promotionallProductsSum;
                }
                orderpromotionproductscounut -= promotionproductcount;
            }

            return promoPrice;
        }
    }
}

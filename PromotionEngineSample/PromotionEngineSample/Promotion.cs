using System;
using System.Collections.Generic;

namespace PromotionEngineSample
{
    public class Promotion
    {
        public int Id { get; set; }

        public Dictionary<Product, int> Products { get; set; }

        public decimal PromoPrice { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime? ObsoleteDate { get; set; }

        public bool IsFixedPrice { get; set; }

        public Promotion(int id, Dictionary<Product, int> products, decimal promoPrice, DateTime activationDate, bool isfixedprice, DateTime? obsoleteDate)
        {
            this.Id = id;
            this.Products = products;
            this.PromoPrice = promoPrice;
            this.ActivationDate = activationDate;
            this.IsFixedPrice = isfixedprice;
            if (obsoleteDate.HasValue)
            {
                this.ObsoleteDate = obsoleteDate;
            }
        }

    }
}

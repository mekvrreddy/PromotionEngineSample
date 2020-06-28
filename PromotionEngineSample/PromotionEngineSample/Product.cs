namespace PromotionEngineSample
{
    public class Product
    {
        public string SKUId { get; set; }

        public decimal UnitPrice { get; set; }

        public Product(string skuId)
        {
            this.SKUId = skuId;

            switch (skuId)
            {
                case "A":
                case "a":
                    this.UnitPrice = 50M;
                    break;

                case "B":
                case "b":
                    this.UnitPrice = 30M;
                    break;

                case "C":
                case "c":
                    this.UnitPrice = 20M;
                    break;

                case "D":
                case "d":
                    this.UnitPrice = 15M;
                    break;
            }
        }
    }
}

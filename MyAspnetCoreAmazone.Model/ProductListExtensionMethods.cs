using System;
using System.Collections.Generic;
using System.Text;

namespace MyAspnetCoreAmazone.Model
{
    public static class ProductListExtensionMethods
    {
        public static void Apply(this IList<Products> products, IDiscountStrategy discountStrategy)
        {
            foreach (Products p in products)
            {
                p.Price.SetDiscountStrategyTo(discountStrategy);
            }
        }
    }
}

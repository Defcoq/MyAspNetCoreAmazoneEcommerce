using System;
using System.Collections.Generic;
using System.Text;

namespace MyAspnetCoreAmazone.Model
{
    public class TradeDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal OriginalSalePrice)
        {
            decimal price = OriginalSalePrice;

            price = price * 0.95M;

            return price;
        }
    }
}

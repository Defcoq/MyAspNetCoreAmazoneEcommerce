using System;
using System.Collections.Generic;
using System.Text;

namespace MyAspnetCoreAmazone.Model
{
    public static class DiscountFactory
    {
        public static IDiscountStrategy GetDiscountStrategyFor(CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.Trade:
                    return new TradeDiscountStrategy();
                default:
                    return new NullDiscountStrategy();
            }
        }
    }

    public enum CustomerType
    {
        Standard = 0,
        Trade = 1
    }
}

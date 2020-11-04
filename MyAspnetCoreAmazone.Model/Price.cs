using System;
using System.Collections.Generic;

namespace MyAspnetCoreAmazone.Model
{
    public partial class Price
    {
      
        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy();
        private decimal _rrp;
        private decimal _sellingPrice;

        public Price(decimal RRP, decimal SellingPrice)
        {
            _rrp = RRP;
            _sellingPrice = SellingPrice;
            Products = new HashSet<Products>();
        }

        public void SetDiscountStrategyTo(IDiscountStrategy DiscountStrategy)
        {
            _discountStrategy = DiscountStrategy;
        }

        public decimal SellingPrice
        {
            get { return _discountStrategy.ApplyExtraDiscountsTo(_sellingPrice); }
            set { }
        }

        public decimal RRP
        {
            get { return _rrp; }
            set { }
        }

        public decimal Discount
        {
            get
            {
                if (RRP > SellingPrice)
                    return (RRP - SellingPrice);
                else
                    return 0;
            }
            set { }
        }

        public decimal Savings
        {
            get
            {
                if (RRP > SellingPrice)
                    return 1 - (SellingPrice / RRP);
                else
                    return 0;
            }
            set { }
        }

        public int PriceId { get; set; }
       // public decimal SellingPrice { get; set; }
        public decimal Rrp { get; set; }
       // public decimal Discount { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}

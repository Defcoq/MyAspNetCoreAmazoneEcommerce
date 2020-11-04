using System;
using System.Collections.Generic;
using System.Text;

namespace MyAspnetCoreAmazone.Model
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Products> GetAllProductsFor(CustomerType customerType)
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);
            IList<Products> products = _productRepository.FindAll();

            products.Apply(discountStrategy);

            return products;
        }
    }
}

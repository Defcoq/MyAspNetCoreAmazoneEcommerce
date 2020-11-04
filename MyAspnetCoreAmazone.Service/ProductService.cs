using System;
using System.Collections.Generic;
using System.Text;

namespace MyAspnetCoreAmazone.Service
{
    public class ProductService : IProductService
    {
        private Model.IProductService _productService;

        public ProductService(Model.IProductService ProductService)
        {
            _productService = ProductService;
        }

        public ProductListResponse GetAllProductsFor(ProductListRequest productListRequest)
        {
            ProductListResponse productListResponse = new ProductListResponse();

            try
            {
                IList<Model.Products> productEntities = _productService.GetAllProductsFor(productListRequest.CustomerType);

                productListResponse.Products = productEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;
            }

            catch (Exception ex)
            {
                // Log the exception...

                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "An error occured";
            }

            return productListResponse;
        }

    }
}

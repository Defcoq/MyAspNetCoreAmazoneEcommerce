﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyAspnetCoreAmazone.Service
{
    public static class ProductMapperExtensionMethods
    {
        public static IList<ProductViewModel> ConvertToProductListViewModel(this IList<Model.Products> products)
        {
            IList<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (Model.Products p in products)
            {
                productViewModels.Add(p.ConvertToProductViewModel());
            }

            return productViewModels;
        }

        public static ProductViewModel ConvertToProductViewModel(this Model.Products product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductId = product.ProductId;
            productViewModel.Name = product.ProductName;
            productViewModel.RRP = String.Format("{0:C}", product.Price.RRP);
            productViewModel.SellingPrice = String.Format("{0:C}", product.Price.SellingPrice);

            if (product.Price.Discount > 0)
                productViewModel.Discount = String.Format("{0:C}", product.Price.Discount);

            if (product.Price.Savings < 1 && product.Price.Savings > 0)
                productViewModel.Savings = product.Price.Savings.ToString("#%");

            return productViewModel;
        }
    }
}

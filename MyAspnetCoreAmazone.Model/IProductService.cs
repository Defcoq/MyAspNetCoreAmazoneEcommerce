using System.Collections.Generic;

namespace MyAspnetCoreAmazone.Model
{
    public interface IProductService
    {
        IList<Products> GetAllProductsFor(CustomerType customerType);
    }
}
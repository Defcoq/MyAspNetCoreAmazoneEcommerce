using System;
using System.Collections.Generic;
using System.Text;

namespace MyAspnetCoreAmazone.Model
{
    public interface IProductRepository
    {
        IList<Products> FindAll();
    }
}

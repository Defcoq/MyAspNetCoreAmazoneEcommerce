using Microsoft.EntityFrameworkCore;
using MyAspnetCoreAmazone.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MyAspnetCoreAmazone.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyAspnetCoreAmazoneContext _ctx;
        private readonly bool _disposeContext;
        public ProductRepository(MyAspnetCoreAmazoneContext context)
        {
            _ctx = context;
        }
        public ProductRepository(DbContextOptions<MyAspnetCoreAmazoneContext> options):  this(new MyAspnetCoreAmazoneContext(options))
        {
            _disposeContext = true;
        }

        public virtual void Dispose()
        {
            if (_disposeContext)
            {
                _ctx.Dispose();
            }
        }
        public IList<Model.Products> FindAll()
        {
            var products = from p in _ctx.Products
                           select new Model.Products
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               Price = new Model.Price(p.RRP, p.SellingPrice)
                           };

            return products.ToList();
        }

    }
}

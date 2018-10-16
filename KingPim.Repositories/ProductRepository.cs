using KingPim.Data;
using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext ctx;

        public ProductRepository(ApplicationDbContext context)
        {
            ctx = context;
        }
        public IEnumerable<Product> Products => ctx.Products;
    }
}

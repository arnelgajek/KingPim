using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class ProductRepository : IProduct
    {
        // Put the Db into a variable to use later on:
        private ApplicationDbContext _ctx;
        public ProductRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public void Update(Product updateProduct)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product deleteProduct)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return _ctx.Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ctx.Products;
        }
    }
}

using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
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

        public void Add(ProductViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newProduct = new Product
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    Price = vm.Price,
                    SubCategory = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                };
                _ctx.Products.Add(newProduct);
            }
            _ctx.SaveChanges();
        }

        public void Update(ProductViewModel vm)
        {
            var ctxProduct = _ctx.Products.FirstOrDefault(p => p.Id.Equals(vm.Id));

            if (ctxProduct != null)
            {
                ctxProduct.Name = vm.Name;
                ctxProduct.Description = vm.Description;
                ctxProduct.Price = vm.Price;
                ctxProduct.UpdatedDate = DateTime.Now;
            }
            _ctx.SaveChanges();
        }

        public Product Delete(int id)
        {
            var ctxProduct = _ctx.Products.FirstOrDefault(p => p.Id.Equals(id));

            if (ctxProduct != null)
            {
                _ctx.Products.Remove(ctxProduct);
                _ctx.SaveChanges();
            }
            else
            {

            }
            return ctxProduct;
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

using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class ProductRepository : IProduct
    {
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
                    SubCategoryId = vm.SubCategoryId,
                    Description = vm.Description,
                    Price = vm.Price,
                    SubCategory = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1,
                    ModifiedByUser = vm.ModifiedByUser
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
                ctxProduct.SubCategoryId = vm.SubCategoryId;
                ctxProduct.UpdatedDate = DateTime.Now;
                ctxProduct.Version++;
                ctxProduct.ModifiedByUser = vm.ModifiedByUser;
            }
            _ctx.SaveChanges();
        }

        public void ProductAttributeValue(ProductViewModel vm)
        {
            var prodAttrValId = _ctx.ProductOneAttributeValues.FirstOrDefault(pal => pal.Id.Equals(vm.Id));

            if (vm.Id == 0)
            {
                var prodAttrVal = new ProductOneAttributeValue
                {
                    Value = vm.Value,
                    OneAttributeId = vm.OneAttributeId,
                    ProductId = vm.ProductId,
            };
            _ctx.ProductOneAttributeValues.Add(prodAttrVal);
            _ctx.SaveChanges();
            }

            // This shit does not work:
            if(prodAttrValId != null)
            {
                prodAttrValId.Value = vm.Value;
                prodAttrValId.OneAttributeId = vm.OneAttributeId;
                prodAttrValId.ProductId = vm.ProductId;
            }
            _ctx.ProductOneAttributeValues.Update(prodAttrValId);
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

        public void GetSubCategories(ProductViewModel vm)
        {
            var prodVm = new ProductViewModel
            {
                Id = vm.Id,
                Name = vm.Name,
                SubCategoryId = vm.SubCategoryId
            };
        }

        public void Publish(ProductViewModel vm)
        {
            var ctxProduct = _ctx.Products.FirstOrDefault(p => p.Id.Equals(vm.Id));

            if (ctxProduct != null)
            {
                ctxProduct.Id = vm.Id;
                ctxProduct.Published = vm.Published;
            }
            _ctx.SaveChanges();
        }
    }
}

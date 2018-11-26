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

        public void AddProductAttributeValue(ProductViewModel vm)
        {
            if (vm.Id == 0)
            {
                // Adding a new product attribute value:
                var newProdAttrVal = new ProductOneAttributeValue
                {
                    Value = vm.Value,
                    ProductId = vm.ProductId,
                    OneAttributeId = vm.OneAttributeId
                };
                _ctx.ProductOneAttributeValues.Add(newProdAttrVal);
            }
            _ctx.SaveChanges();
        }

        public void UpdateProductAttributeValue(ProductViewModel vm)
        {
            var ctxProductAttributeValue = _ctx.ProductOneAttributeValues.FirstOrDefault(pav => pav.Id.Equals(vm.Id));

            if (ctxProductAttributeValue != null)
            {
                ctxProductAttributeValue.Value = vm.Value;
                ctxProductAttributeValue.ProductId = vm.ProductId;
                ctxProductAttributeValue.OneAttributeId = vm.OneAttributeId;
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

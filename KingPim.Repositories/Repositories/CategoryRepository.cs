using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class CategoryRepository : ICategory
    {
        private ApplicationDbContext _ctx;
        public CategoryRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(CategoryViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newCategory = new Category
                {
                    Name = vm.Name,
                    SubCategories = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,                    
                    Published = false
                };
                _ctx.Categories.Add(newCategory);
            }
            _ctx.SaveChanges();
        }

        public void Update(CategoryViewModel vm)
        {
            var ctxCategory = _ctx.Categories.FirstOrDefault(c => c.Id.Equals(vm.Id));

            if (ctxCategory != null)
            {
                ctxCategory.Name = vm.Name;
                ctxCategory.UpdatedDate = DateTime.Now;
            }
            
            _ctx.SaveChanges();
        }

        public Category Delete(int id)
        {
            var ctxCategory = _ctx.Categories.FirstOrDefault(c => c.Id.Equals(id));
            if (ctxCategory != null)
            {
                _ctx.Categories.Remove(ctxCategory);
                _ctx.SaveChanges();
            }
            else
            {

            }
            return ctxCategory;
        }

        public Category Get(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _ctx.Categories;
        }

        public void Publish(CategoryViewModel vm)
        {
            var ctxCategory = _ctx.Categories.FirstOrDefault(c => c.Id.Equals(vm.Id));

            if (ctxCategory != null)
            {
                ctxCategory.Id = vm.Id;
                ctxCategory.Published = vm.Published;
            }
            _ctx.SaveChanges();
        }
    }
}

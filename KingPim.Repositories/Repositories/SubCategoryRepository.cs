﻿using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class SubCategoryRepository : ISubCategory
    {
        // Put the Db into a variable to use later on:
        private ApplicationDbContext _ctx;
        public SubCategoryRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(SubCategoryViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newSubCategory = new SubCategory
                {
                    Name = vm.Name,
                    Products = null,
                    AttributeGroups = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                };
                _ctx.SubCategories.Add(newSubCategory);
            }
            _ctx.SaveChanges();
        }

        public void Update(SubCategoryViewModel vm)
        {
            var ctxSubCategory = _ctx.SubCategories.FirstOrDefault(scn => scn.Id.Equals(vm.Id));

            if (ctxSubCategory != null)
            {
                ctxSubCategory.Name = vm.Name;
                ctxSubCategory.UpdatedDate = DateTime.Now;
            }
            _ctx.SaveChanges();
        }

        public SubCategory Delete(int id)
        {
            var ctxSubCategory = _ctx.SubCategories.FirstOrDefault(sc => sc.Id.Equals(id));

            if (ctxSubCategory != null)
            {
                _ctx.SubCategories.Remove(ctxSubCategory);
                _ctx.SaveChanges();
            }
            else
            {

            }
            return ctxSubCategory;
        }

        public SubCategory Get(int id)
        {
            return _ctx.SubCategories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _ctx.SubCategories;
        }
    }
}

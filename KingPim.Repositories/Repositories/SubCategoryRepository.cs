﻿using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class SubCategoryRepository : ISubCategory
    {
        private ApplicationDbContext _ctx;
        public SubCategoryRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(SubCategoryViewModel vm)
        {
            if (vm.Id == 0)
            {
                var testList = new List<SubCategoryAttributeGroup>();

                foreach (var attrGrId in vm.AttributeGroupId)
                {
                    var newSubCategoryAttributeGroup = new SubCategoryAttributeGroup
                    {
                        SubCategoryId = vm.SubCategoryId,
                        AttributeGroupId = attrGrId,
                    };
                    testList.Add(newSubCategoryAttributeGroup);
                }

                var newSubCategory = new SubCategory
                {
                    Name = vm.Name,
                    CategoryId = vm.CategoryId,                    
                    SubCategoryAttributeGroups = testList,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1,
                    ModifiedByUser = vm.ModifiedByUser
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
                ctxSubCategory.CategoryId = vm.CategoryId;
                ctxSubCategory.UpdatedDate = DateTime.Now;
                ctxSubCategory.Version++;
                ctxSubCategory.ModifiedByUser = vm.ModifiedByUser;
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

        public void Publish(SubCategoryViewModel vm)
        {
            var ctxSubCategory = _ctx.SubCategories.FirstOrDefault(c => c.Id.Equals(vm.Id));

            if (ctxSubCategory != null)
            {
                ctxSubCategory.Id = vm.Id;
                ctxSubCategory.Published = vm.Published;
            }
            _ctx.SaveChanges();
        }
    }
}

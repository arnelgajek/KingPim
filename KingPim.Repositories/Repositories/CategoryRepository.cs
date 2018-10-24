﻿using KingPim.Data;
using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class CategoryRepository : ICategory
    {
        // Put the Db into a variable to use later on:
        private ApplicationDbContext _ctx;
        public CategoryRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public void Update(Category updateCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category deleteCategory)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _ctx.Categories;
        }
    }
}
using KingPim.Data;
using KingPim.Models.Models;
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

        public void Add(SubCategory subCategory)
        {
            throw new NotImplementedException();
        }

        public void Update(SubCategory updateSubCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubCategory deleteSubCategory)
        {
            throw new NotImplementedException();
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

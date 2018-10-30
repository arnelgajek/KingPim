using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface ISubCategory
    {
        IEnumerable<SubCategory> GetAll();
        SubCategory Get(int id);
        void Add(SubCategoryViewModel newSubCategory);
        void Update(SubCategoryViewModel updateSubCategory);
        SubCategory Delete(int id);
    }
}

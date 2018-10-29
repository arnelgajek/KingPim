using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(CreateCategoryViewModel newCategory);
        void Update(UpdateCategoryViewModel updateCategory);
        Category Delete(int id);
    }
}

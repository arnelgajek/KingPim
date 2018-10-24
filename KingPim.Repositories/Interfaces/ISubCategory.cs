using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface ISubCategory
    {
        IEnumerable<SubCategory> GetAll();
        SubCategory Get(int id);
        void Add(SubCategory newSubCategory);
        void Update(SubCategory updateSubCategory);
        void Delete(SubCategory deleteSubCategory);
    }
}

using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Infrastructure.Helpers
{
    public class ExportHelper
    {
        public static List<CategoryViewModel> GetCategoriesToXml(IEnumerable<Category> allCategories)
        {
            var catVmList = new List<CategoryViewModel>();

            foreach (var cat in allCategories)
            {
                catVmList.Add(
                    new CategoryViewModel
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        Published = cat.Published,
                        SubCategories = GetSubCategoriesToXml(cat.SubCategories)
                    });
            }
            return catVmList;
        }

        private static List<SubCategoryViewModel> GetSubCategoriesToXml(List<SubCategory> allSubCategories)
        {
            var subCatVmList = new List<SubCategoryViewModel>();

            foreach (var subCat in allSubCategories)
            {
                subCatVmList.Add(
                    new SubCategoryViewModel
                    {
                        Id = subCat.Id,
                        Name = subCat.Name,
                        Published = subCat.Published                        
                    });
            }
            return subCatVmList;
        }
    }
}

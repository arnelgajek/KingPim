using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class SubCategoryCrudVc : ViewComponent
    {
        private ISubCategory subCatRepo;

        public SubCategoryCrudVc(ISubCategory subCatRepository)
        {
            subCatRepo = subCatRepository;
        }

        public IViewComponentResult Invoke()
        {
            var subCatVm = new SubCategoryViewModel();

            return View(subCatVm);
        }
    }
}

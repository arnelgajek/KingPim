using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class CategoryCrudVc : ViewComponent
    {
        private ICategory catRepo;

        public CategoryCrudVc(ICategory catRepository)
        {
            catRepo = catRepository;
        }

        public IViewComponentResult Invoke()
        {
            var catVm = new CategoryViewModel();

            return View(catVm);
        }
    }
}

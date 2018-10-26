using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class CrudViewComponent : ViewComponent
    {
        private ICategory catRepo;

        public CrudViewComponent(ICategory catRepository)
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

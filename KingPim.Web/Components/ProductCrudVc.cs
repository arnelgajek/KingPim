using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class ProductCrudVc : ViewComponent
    {
        private IProduct prodRepo;

        public ProductCrudVc(IProduct prodRepository)
        {
            prodRepo = prodRepository;
        }

        public IViewComponentResult Invoke()
        {
            var prodVm = new ProductViewModel();

            return View(prodVm);
        }
    }
}

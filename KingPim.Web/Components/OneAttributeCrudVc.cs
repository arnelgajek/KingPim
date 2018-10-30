using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class OneAttributeCrudVc : ViewComponent
    {
        private IOneAttribute oneAttrRepo;

        public OneAttributeCrudVc(IOneAttribute oneAttrRepository)
        {
            oneAttrRepo = oneAttrRepository;
        }

        public IViewComponentResult Invoke()
        {
            var oneAttrVm = new OneAttributeViewModel();

            return View(oneAttrVm);
        }
    }
}

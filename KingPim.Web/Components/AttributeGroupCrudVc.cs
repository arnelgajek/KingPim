using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class AttributeGroupCrudVc : ViewComponent
    {
        private IAttributeGroup attrGroupRepo;

        public AttributeGroupCrudVc(IAttributeGroup attrGroupRepository)
        {
            attrGroupRepo = attrGroupRepository;
        }

        public IViewComponentResult Invoke()
        {
            var attrGroupVm = new AttributeGroupViewModel();

            return View(attrGroupVm);
        }
    }
}

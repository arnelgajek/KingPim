using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class OneAttributeCrudVc : ViewComponent
    {
        private IOneAttribute oneAttrRepo;

        public OneAttributeCrudVc(IOneAttribute oneAttrRepository)
        {
            oneAttrRepo = oneAttrRepository;
        }

        public IViewComponentResult Invoke(OneAttributeViewModel vm)
        {
            var oneAttrVm = new OneAttributeViewModel();

            return View(vm);
        }
    }
}

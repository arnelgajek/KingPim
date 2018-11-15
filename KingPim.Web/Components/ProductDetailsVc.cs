using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KingPim.Web.Components
{
    public class ProductDetailsVc : ViewComponent
    {
        private IProduct prodRepo;
        private IAttributeGroup attrGroupRepo;
        private IOneAttribute oneAttributeRepo;

        public ProductDetailsVc(IProduct prodRepository, IAttributeGroup attrGroupRepository, IOneAttribute oneAttrRepository)
        {
            prodRepo = prodRepository;
            attrGroupRepo = attrGroupRepository;
            oneAttributeRepo = oneAttrRepository;
        }

        public IViewComponentResult Invoke(int id)
        {
            var prodDetailsVm = new ProductDetailsViewModel()
            {
                Product = prodRepo.Get(id),
                AttributeGroup = attrGroupRepo.Get(id),
                OneAttribute = oneAttributeRepo.Get(id)
            };

            return View(prodDetailsVm);
        }
    }
}

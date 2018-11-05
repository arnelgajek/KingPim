using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace KingPim.Web.Controllers
{
    // TODO: Don't forget to add authorization!
    public class AttributeGroupController : Controller
    {
        private IAttributeGroup attrGroupRepo;
        private ISubCategory subCatRepo;

        public AttributeGroupController(IAttributeGroup attrGroupRepository, ISubCategory subCatRepository)
        {
            attrGroupRepo = attrGroupRepository;
            subCatRepo = subCatRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var attrGroupVm = new AttributeGroupViewModel
            {
                AttributeGroups = attrGroupRepo.GetAll(),
                SubCategories = subCatRepo.GetAll()
            };
            return View(attrGroupVm);
        }

        [HttpPost]
        public IActionResult Add(AttributeGroupViewModel vm)
        {
            attrGroupRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(attrGroupRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(AttributeGroupViewModel vm)
        {
            attrGroupRepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleteAttrGroup = attrGroupRepo.Delete(id);
            if (deleteAttrGroup != null)
            {

            }
            else
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

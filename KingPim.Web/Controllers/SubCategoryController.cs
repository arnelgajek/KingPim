using KingPim.Models.ViewModels;
using KingPim.Repositories;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class SubCategoryController : Controller
    {
        private ISubCategory subCatrepo;
        private ICategory catRepo;
        private IAttributeGroup attrGroupRepo;

        public SubCategoryController (ISubCategory subCatRepository, ICategory catRepository, IAttributeGroup attrGroupRepository)
        {
            subCatrepo = subCatRepository;
            catRepo = catRepository;
            attrGroupRepo = attrGroupRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var subCatVm = new SubCategoryViewModel
            {
                SubCategories = subCatrepo.GetAll(),
                Categories = catRepo.GetAll(),
                AttributeGroups = attrGroupRepo.GetAll()
            };

            return View(subCatVm);
        }

        [HttpPost]
        public IActionResult Add(SubCategoryViewModel vm)
        {
            subCatrepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(subCatrepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(SubCategoryViewModel vm)
        {
            subCatrepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedSubCategory = subCatrepo.Delete(id);
            if (deletedSubCategory != null)
            {

            }
            else
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

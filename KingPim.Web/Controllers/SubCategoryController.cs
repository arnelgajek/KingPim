using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    // TODO: Don't forget to add authorization!
    public class SubCategoryController : Controller
    {
        private ISubCategory subCatrepo;
        private ICategory catRepo;

        public SubCategoryController (ISubCategory subCatRepository, ICategory catRepository)
        {
            subCatrepo = subCatRepository;
            catRepo = catRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var subCatVm = new SubCategoryViewModel
            {
                Categories = catRepo.GetAll(),
                SubCategories = subCatrepo.GetAll()

            };

            return View(subCatVm);
        }

        //[HttpGet]
        //public IActionResult GetCategories()
        //{
        //    var subCatVm = new SubCategoryViewModel
        //    {
        //        Categories = catRepo.GetAll(),
        //        SubCategories = subCatrepo.GetAll()
                
        //    };
        //    return View(subCatVm);
        //}

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

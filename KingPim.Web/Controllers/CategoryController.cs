using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    // TODO: Don't forget to add authorization!
    public class CategoryController : Controller
    {
        private ICategory catRepo;

        public CategoryController(ICategory catRepository)
        {
            catRepo = catRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var catVm = new CategoryViewModel
            {
                Categories = catRepo.GetAll()
            };
            return View(catVm);
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel vm)
        {
            catRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {        
            return View(catRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(CategoryViewModel vm)
        {
            catRepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedCategory = catRepo.Delete(id);
            if (deletedCategory != null)
            {

            }
            else
            {

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Publish(CategoryViewModel vm)
        {
            catRepo.Publish(vm);
            return Json(vm);
        }
    }
}

using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // TODO: Don't forget to add authorization!
        private IProduct prodRepo;
        private ISubCategory subCatrepo;

        public ProductController(IProduct prodRepository, ISubCategory subCatRepository)
        {
            prodRepo = prodRepository;
            subCatrepo = subCatRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var prodVm = new ProductViewModel
            {
                Products = prodRepo.GetAll(),
                SubCategories = subCatrepo.GetAll()
            };
            
            return View(prodVm);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel vm)
        {
            prodRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(prodRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel vm)
        {
            prodRepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Publish(ProductViewModel vm)
        {
            prodRepo.Publish(vm);
            return Json(vm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedProduct = prodRepo.Delete(id);
            if (deletedProduct != null)
            {

            }
            else
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    public class ProductController : Controller
    {
        // TODO: Don't forget to add authorization!
        private IProduct prodRepo;

        public ProductController(IProduct prodRepository)
        {
            prodRepo = prodRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var prod = prodRepo.GetAll();
            return View(prod);
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

using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var cat = catRepo.GetAll();
            return View(cat);
        }

        [HttpPost]
        public IActionResult Add(CreateCategoryViewModel vm)
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
        public IActionResult Update(UpdateCategoryViewModel vm)
        {
            catRepo.Update(vm);
            var url = Url.Action("Index", "Category");
            return Json(url);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}

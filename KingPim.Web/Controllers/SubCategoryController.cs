using KingPim.Repositories;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    public class SubCategoryController : Controller
    {
        // TODO: Connect to database with private property and private cunstructor.
        private ISubCategory subCatrepo;

        public SubCategoryController (ISubCategory subCatRepository)
        {
            subCatrepo = subCatRepository;
        }

        public IActionResult Index()
        {
            var subCat = subCatrepo.GetAll();

            return View(subCat);
        }

        // TODO: Add
        public IActionResult Add()
        {
            return View();
        }

        // TODO: Get
        public IActionResult Get(int id)
        {
            return View(subCatrepo.Get(id));
        }

        // TODO: GetAll
        public IActionResult GetAll()
        {
            var subCat = subCatrepo.GetAll();

            return View(subCat);
        }

        // TODO: Update
        public IActionResult Update(int Id)
        {
            return View();
        }

        // TODO: Delete
        public IActionResult Delete(int Id)
        {
            return View();
        }
    }
}

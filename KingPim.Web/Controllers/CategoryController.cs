using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    public class CategoryController : Controller
    {
        // TODO: Connect to database with private property and private cunstructor.
        private ICategory repo;

        public CategoryController(ICategory catRepository)
        {
            repo = catRepository;
        }

        public IActionResult Index()
        {
            var cat = repo.GetAll();

            return View(cat);
        }

        // TODO: Add
        public IActionResult Add()
        {
            return View();
        }

        // TODO: Get
        public IActionResult Get(int Id)
        {
            return View();
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

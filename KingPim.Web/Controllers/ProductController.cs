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
        // TODO: Connect to database with private property and private cunstructor.
        private IProduct prodRepo;

        public ProductController(IProduct prodRepository)
        {
            prodRepo = prodRepository;
        }

        public IActionResult Index()
        {
            var prod = prodRepo.GetAll();
            return View(prod);
        }

        // TODO: Add
        public IActionResult Add()
        {
            return View();
        }

        // TODO: Get
        public IActionResult Get(int id)
        {
            return View(prodRepo.Get(id));
        }

        // TODO: Update
        public IActionResult Update(int id)
        {
            return View();
        }

        // TODO: Delete
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}

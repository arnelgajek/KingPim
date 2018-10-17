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

        public IActionResult Index()
        {
            // TODO: Where should this one be returned?
            return View();
        }

        // TODO: Add
        public IActionResult Add(int Id)
        {
            return View();
        }

        // TODO: Get
        public IActionResult Get(int Id)
        {
            return View();
        }

        // TODO: GetAll
        public IActionResult GetAll()
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

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    using KingPim.Repositories.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class OneAttributeController : Controller
    {
        private IOneAttribute oneAttrRepo;

        public OneAttributeController(IOneAttribute oneAttrRepository)
        {
            oneAttrRepo = oneAttrRepository;
        }
        public IActionResult Index()
        {
            var oneAttr = oneAttrRepo.GetAll();
            return View(oneAttr);
        }

        // TODO: Add
        public IActionResult Add()
        {
            return View();
        }

        // TODO: Get
        public IActionResult Get(int id)
        {
            return View(oneAttrRepo.Get(id));
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

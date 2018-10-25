using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    // TODO: Don't forget to add authorization!
    public class AttributeGroupController : Controller
    {
        // TODO: Connect to database with private property and private cunstructor.
        private IAttributeGroup attrGroupRepo;

        public AttributeGroupController(IAttributeGroup attrGroupRepository)
        {
            attrGroupRepo = attrGroupRepository;
        }

        public IActionResult Index()
        {
            var attrGroup = attrGroupRepo.GetAll();
            return View(attrGroup);
        }

        // TODO: Add
        public IActionResult Add()
        {
            return View();
        }

        // TODO: Get
        public IActionResult Get(int id)
        {
            return View(attrGroupRepo.Get(id));
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

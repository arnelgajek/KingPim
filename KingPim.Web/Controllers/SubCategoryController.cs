using KingPim.Models.ViewModels;
using KingPim.Repositories;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    // TODO: Don't forget to add authorization!
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

        public IActionResult Add(SubCategoryViewModel vm)
        {
            subCatrepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Get(int id)
        {
            return View(subCatrepo.Get(id));
        }

        public IActionResult Update(SubCategoryViewModel vm)
        {
            subCatrepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var deletedSubCategory = subCatrepo.Delete(id);
            if (deletedSubCategory != null)
            {

            }
            else
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

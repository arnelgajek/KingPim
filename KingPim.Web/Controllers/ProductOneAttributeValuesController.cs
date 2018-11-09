using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace KingPim.Web.Controllers
{
    [Authorize]
    public class ProductOneAttributeValuesController : Controller
    {
        private IProductOneAttributeValues prodOneAttrValRepo;

        public ProductOneAttributeValuesController(IProductOneAttributeValues prodOneAttrValRepository)
        {
            prodOneAttrValRepo = prodOneAttrValRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var prodAttrOneGroup = prodOneAttrValRepo.GetAll();
            return View(prodAttrOneGroup);
        }
    }
}

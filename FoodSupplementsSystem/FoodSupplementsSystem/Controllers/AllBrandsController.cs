using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;
using System.Web.Mvc;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using System.Web;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllBrandsController : Controller
    {
        private IBrandsService brands;

        public AllBrandsController(IBrandsService brands)
        {
            Guard.WhenArgument(brands, "brands").IsNull().Throw();

            this.brands = brands;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var resultBrands = brands.GetAll().ProjectTo<BrandViewModel>().ToList();

            return View(resultBrands);
        }
    }
}
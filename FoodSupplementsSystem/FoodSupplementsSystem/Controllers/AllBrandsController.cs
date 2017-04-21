using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;
using System.Web.Mvc;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using System.Web;
using System.Data.Entity;

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
            var resultBrands = brands.GetAll().Include(b => b.Supplements).ProjectTo<BrandViewModel>().ToList();

            return View(resultBrands);
        }
    }
}
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;

using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllBrandsController : Controller
    {
        private readonly IBrandsService brands;

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
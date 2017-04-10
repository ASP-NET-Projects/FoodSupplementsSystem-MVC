using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Models.AllBrands;
using FoodSupplementsSystem.Models.AllCategories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    public class HomeController : Controller
    {
        private ICategoriesService categories;

        private IBrandsService brands;

        private ISupplementsService supplements;

        private IHomeService homeServices;

        public HomeController(ICategoriesService categories, IBrandsService brands, ISupplementsService supplements, IHomeService homeServices)
        {
            Guard.WhenArgument(categories, "categories").IsNull().Throw();
            Guard.WhenArgument(brands, "brands").IsNull().Throw();
            Guard.WhenArgument(supplements, "supplements").IsNull().Throw();

            this.categories = categories;
            this.brands = brands;
            this.supplements = supplements;

            this.homeServices = homeServices;
        }

        public ActionResult Index()
        {

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult MostCommentedTopics()
        {
            return PartialView("_MostCommentedTopicsPartial", this.homeServices.GetTopicViewModel(6));
        }

        [ChildActionOnly]
        public ActionResult TopBrands()
        {
            var resultBrands = this.brands.GetAll().Take(3).ProjectTo<BrandViewModel>().ToList(); ;

            return PartialView("_TopBrands", resultBrands);
        }

        [ChildActionOnly]
        public ActionResult TopCategories()
        {
            var resultCategories = this.categories.GetAll().Take(3).ProjectTo<CategoryViewModel>().ToList(); ;

            return PartialView("_TopCategories", resultCategories);
        }

        [ChildActionOnly]
        public ActionResult TopSupplements()
        {
            var resultSupplements = this.supplements.GetAll().Take(3).ProjectTo<SupplementViewModel>().ToList(); ;

            return PartialView("_TopSupplements", resultSupplements);
        }
    }
}
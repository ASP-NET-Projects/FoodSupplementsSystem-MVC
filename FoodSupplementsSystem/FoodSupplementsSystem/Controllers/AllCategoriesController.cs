using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using FoodSupplementsSystem.ViewModels.AllCategories;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllCategoriesController : Controller
    {
        private ICategoriesService categories;

        public AllCategoriesController(ICategoriesService categories)
        {
            Guard.WhenArgument(categories, "categories").IsNull().Throw();

            this.categories = categories;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var resultCategories = categories.GetAll().ProjectTo<CategoryViewModel>().ToList();

            return View(resultCategories);
        }
    }
}
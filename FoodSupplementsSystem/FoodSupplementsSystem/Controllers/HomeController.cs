using System.Web.Mvc;

using Bytes2you.Validation;

using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Infrastructure.Services.Contracts;

namespace FoodSupplementsSystem.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService homeServices;

        public HomeController(IHomeService homeServices)
        {
            Guard.WhenArgument(homeServices, "homeServices").IsNull().Throw();

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
        [OutputCache(Duration = 60 * 60)]
        public ActionResult TopBrands()
        {
            return PartialView("_TopBrands", this.homeServices.GetLastBrands());
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult TopCategories()
        {
            return PartialView("_TopCategories", this.homeServices.GetLastCategories());
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult TopSupplements()
        {
            return PartialView("_TopSupplements", this.homeServices.GetLastSupplements());
        }
    }
}
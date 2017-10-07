using System.Web.Mvc;
using System.Linq;
using System.Web;

using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllSupplements;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllSupplementsController : Controller
    {
        private ISupplementsService supplements;

        private IDropDownListPopulator populator;

        public AllSupplementsController(ISupplementsService supplements, IDropDownListPopulator populator)
        {
            Guard.WhenArgument(supplements, "supplements").IsNull().Throw();
            Guard.WhenArgument(populator, "populator").IsNull().Throw();

            this.supplements = supplements;
            this.populator = populator;
        }

        [HttpGet]
        public ActionResult All(int? category, int? brand, int? topic)
        {
            var filterSupplementsModel = new FilterSupplementsViewModel
            {
                Category = category,
                Brand = brand,
                Topic = topic
            };

            return View(filterSupplementsModel);
        }

        [HttpPost]
        public ActionResult ReadSupplements([DataSourceRequest]DataSourceRequest request, int? category, int? brand, int? topic)
        {
            var supplementsQuery = this.supplements.GetAll();

            if (category != null)
            {
                supplementsQuery = supplementsQuery.Where(s => s.CategoryId == category.Value);
            }

            if (brand != null)
            {
                supplementsQuery = supplementsQuery.Where(s => s.BrandId == brand.Value);
            }

            if (topic != null)
            {
                supplementsQuery = supplementsQuery.Where(s => s.TopicId == topic.Value);
            }

            var resultSupplements = supplementsQuery
                .ProjectTo<ListSupplementViewModel>();

            return Json(resultSupplements.ToDataSourceResult(request));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var supplement = this.supplements
                .GetAll()
                .Where(s => s.Id == id)
                .ProjectTo<DetailsSupplementViewModel>()
                .FirstOrDefault();

            if (supplement == null)
            {
                throw new HttpException(404, "Supplement not found");
            }

            return View(supplement);
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            return Json(this.populator.GetCategories(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBrands()
        {
            return Json(this.populator.GetBrands(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTopics()
        {
            return Json(this.populator.GetTopics(), JsonRequestBehavior.AllowGet);
        }
    }
}
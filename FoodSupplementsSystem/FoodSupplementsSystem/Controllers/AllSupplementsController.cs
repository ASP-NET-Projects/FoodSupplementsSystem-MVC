using AutoMapper.QueryableExtensions;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System.Linq;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllSupplementsController : Controller
    {
        private ISupplementsService supplements;

        private IDropDownListPopulator populator;

        public AllSupplementsController(ISupplementsService supplements, IDropDownListPopulator populator)
        {
            this.supplements = supplements;
            this.populator = populator;
        }

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

        public ActionResult GetCategories()
        {
            return Json(this.populator.GetCategories(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBrands()
        {
            return Json(this.populator.GetBrands(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTopics()
        {
            return Json(this.populator.GetTopics(), JsonRequestBehavior.AllowGet);
        }
    }
}
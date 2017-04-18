using AutoMapper.QueryableExtensions;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System.IO;
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

        public ActionResult All(int? category)
        {
            return View(category);
        }

        [HttpPost]
        public ActionResult ReadSupplements([DataSourceRequest]DataSourceRequest request, int? category)
        {
            var supplementsQuery = this.supplements.GetAll();

            if (category != null)
            {
                supplementsQuery = supplementsQuery.Where(t => t.CategoryId == category.Value);
            }

            var resultSupplements = supplementsQuery
                .ProjectTo<ListSupplementViewModel>().ToList();

            return Json(resultSupplements.ToDataSourceResult(request));
        }

        public ActionResult GetCategories()
        {
            return Json(this.populator.GetCategories(), JsonRequestBehavior.AllowGet);
        }
    }
}
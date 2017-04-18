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
    public class AllSupplementsController : Controller
    {
        private ISupplementsService supplements;

        private IDropDownListPopulator populator;

        public AllSupplementsController(ISupplementsService supplements, IDropDownListPopulator populator)
        {
            this.supplements = supplements;
            this.populator = populator;
        }

        public ActionResult All()
        {
            return View();
        }

        public ActionResult ReadSupplements([DataSourceRequest]DataSourceRequest request)
        {
            var resultSupplements = supplements.GetAll()
                .ProjectTo<ListSupplementViewModel>();

            return Json(resultSupplements.ToDataSourceResult(request));
        }

        public ActionResult GetCategories()
        {
            return Json(this.populator.GetCategories(), JsonRequestBehavior.AllowGet);
        }
    }
}
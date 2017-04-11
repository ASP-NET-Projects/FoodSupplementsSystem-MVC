using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using FoodSupplementsSystem.Areas.Administration.ViewModels;
using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Services.Data.Contracts;
using AutoMapper.QueryableExtensions;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    public class SupplementsController : Controller
    {
        private ISupplementsService supplements;

        public SupplementsController(ISupplementsService supplements)
        {
            this.supplements = supplements;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SupplementViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            var resultSupplements = supplements.GetAll().ProjectTo<SupplementViewModel>();

            return Json(resultSupplements.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SupplementViewModels_Create([DataSourceRequest]DataSourceRequest request, SupplementViewModel supplement)
        {
            if (supplement != null && this.ModelState.IsValid)
            {
                this.supplements.Create(supplement.Name, supplement.ImageUrl, supplement.Ingredients, supplement.Use, supplement.Description);
            }

            return Json(new[] { supplement }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SupplementViewModels_Update([DataSourceRequest]DataSourceRequest request, SupplementViewModel supplement)
        {
            if (ModelState.IsValid)
            {
                if (supplement != null && this.ModelState.IsValid)
                {
                    this.supplements.UpdateById(supplement.Id, supplement.Name, supplement.ImageUrl, supplement.Ingredients, supplement.Use, supplement.Description);
                }
            }

            return Json(new[] { supplement }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SupplementViewModels_Destroy([DataSourceRequest]DataSourceRequest request, SupplementViewModel supplement)
        {
            if (ModelState.IsValid)
            {
                if (supplement != null && this.ModelState.IsValid)
                {
                    this.supplements.DeleteById(supplement.Id);
                }
            }

            return Json(new[] { supplement }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

       //protected override void Dispose(bool disposing)
       //{
       //    db.Dispose();
       //    base.Dispose(disposing);
       //}
    }
}

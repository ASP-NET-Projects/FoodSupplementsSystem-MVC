using System;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using AutoMapper.QueryableExtensions;

using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : Controller
    {
        private IBrandsService brands;

        public BrandsController(IBrandsService brands)
        {
            this.brands = brands;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Brands_Read([DataSourceRequest]DataSourceRequest request)
        {
            var resultBrands = brands.GetAll().ProjectTo<BrandViewModel>();

            return Json(resultBrands.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Brands_Create([DataSourceRequest]DataSourceRequest request, BrandViewModel brand)
        {
            if (brand != null && this.ModelState.IsValid)
            {
                this.brands.Create(brand.Name, brand.WebSite);
            }

            return Json(new[] { brand }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Brands_Update([DataSourceRequest]DataSourceRequest request, BrandViewModel brand)
        {
            if (ModelState.IsValid)
            {
                if (brand != null && this.ModelState.IsValid)
                {
                    this.brands.UpdateById(brand.Id, brand.Name, brand.WebSite);
                }
            }

            return Json(new[] { brand }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Brands_Destroy([DataSourceRequest]DataSourceRequest request, BrandViewModel brand)
        {
            if (ModelState.IsValid)
            {
                if (brand != null && this.ModelState.IsValid)
                {
                    this.brands.DeleteById(brand.Id);
                }
            }

            return Json(new[] { brand }.ToDataSourceResult(request, ModelState));
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

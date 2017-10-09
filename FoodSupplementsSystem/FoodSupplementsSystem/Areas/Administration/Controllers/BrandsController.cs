using System;
using System.Web.Mvc;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : Controller
    {
        private IBrandsService brands;

        public BrandsController(IBrandsService brands)
        {
            Guard.WhenArgument(brands, "brands").IsNull().Throw();

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
                var brandDbModel = Mapper.Map<Brand>(brand);
                this.brands.Create(brandDbModel);
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
                    var brandDbModel = Mapper.Map<Brand>(brand);
                    this.brands.Update(brandDbModel);
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
                    var brandDbModel = Mapper.Map<Brand>(brand);
                    this.brands.Delete(brandDbModel);
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

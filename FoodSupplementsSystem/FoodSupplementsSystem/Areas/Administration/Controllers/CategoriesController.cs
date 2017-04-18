using System;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Areas.Administration.ViewModels;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            Guard.WhenArgument(categories, "categories").IsNull().Throw();

            this.categories = categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            var resultCategories = categories.GetAll().ProjectTo<CategoryViewModel>();

            return Json(resultCategories.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && this.ModelState.IsValid)
            {
                this.categories.Create(category.Name);
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                if (category != null && this.ModelState.IsValid)
                {
                    this.categories.UpdateNameById(category.Id, category.Name);
                }
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Destroy([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                if (category != null && this.ModelState.IsValid)
                {
                    this.categories.DeleteById(category.Id);
                }
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

       // protected override void Dispose(bool disposing)
       // {
       //     categoriesWrapper.Dispose();
       //     base.Dispose(disposing);
       // }
    }
}

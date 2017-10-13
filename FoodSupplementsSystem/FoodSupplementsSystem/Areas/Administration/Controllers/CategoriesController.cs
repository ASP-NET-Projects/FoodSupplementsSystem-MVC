using System.Web.Mvc;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Categories;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categories;

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
                var categoryDbModel = Mapper.Map<Category>(category);
                this.categories.Create(categoryDbModel);
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
                    var categoryDbModel = Mapper.Map<Category>(category);
                    this.categories.Update(categoryDbModel);
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
                    var categoryDbModel = Mapper.Map<Category>(category);
                    this.categories.Delete(categoryDbModel);
                }
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
    }
}

using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Areas.Administration.Models;
using AutoMapper;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.Data;
using AutoMapper.QueryableExtensions;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        //private FoodSupplementsSystemDbContext db = new FoodSupplementsSystemDbContext();

        private ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            //IQueryable<Category> categories = this.categories.GetAll();
            //DataSourceResult result = categories.ToDataSourceResult(request, category => new
            //{
            //    Id = category.Id,
            //    Name = category.Name
            //});
            //
            //return Json(result);

            //var comments = this.comments
            //   .All()
            //   .To<CommentViewModel>();
            //
            //return this.Json(comments.ToDataSourceResult(request));

            var categories = this.categories.GetAll().ProjectTo<CategoryViewModel>();

            return this.Json(categories.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && this.ModelState.IsValid)
            {
                //var entity = new Category
                //{
                //    Name = category.Name
                //};
                //
                //
                //db.Categories.Add(entity);
                //db.SaveChanges();
                //category.Id = entity.Id;

                this.categories.Create(category.Name);
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                // var entity = new Category
                // {
                //     Id = category.Id,
                //     Name = category.Name
                // };
                //
                // db.Categories.Attach(entity);
                // db.Entry(entity).State = EntityState.Modified;
                // db.SaveChanges();

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
                //var entity = new Category
                //{
                //    Id = category.Id,
                //    Name = category.Name
                //};
                //
                //db.Categories.Attach(entity);
                //db.Categories.Remove(entity);
                //db.SaveChanges();

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

       //protected override void Dispose(bool disposing)
       //{
       //    db.Dispose();
       //    base.Dispose(disposing);
       //}
    }
}

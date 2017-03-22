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
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private FoodSupplementsSystemDbContext db = new FoodSupplementsSystemDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Category> categories = db.Categories;
            DataSourceResult result = categories.ToDataSourceResult(request, category => new {
                Id = category.Id,
                Name = category.Name
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, Category category)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = category.Name
                };

                db.Categories.Add(entity);
                db.SaveChanges();
                category.Id = entity.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, Category category)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Id = category.Id,
                    Name = category.Name
                };

                db.Categories.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Destroy([DataSourceRequest]DataSourceRequest request, Category category)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Id = category.Id,
                    Name = category.Name
                };

                db.Categories.Attach(entity);
                db.Categories.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

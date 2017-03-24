using AutoMapper.QueryableExtensions;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Models.AllCategories;
using FoodSupplementsSystem.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllCategoriesController : Controller
    {
        private IRepository<Category> categoriesWrapper;

        private ICategoriesService categories;

        public AllCategoriesController(ICategoriesService categories, IRepository<Category> categoriesWrapper)
        {
            this.categories = categories;
            this.categoriesWrapper = categoriesWrapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IQueryable<Category> categories = categoriesWrapper.All();

            var resultCategories = categories.ProjectTo<CategoryViewModel>().ToList();

            return View(resultCategories);
        }
    }
}
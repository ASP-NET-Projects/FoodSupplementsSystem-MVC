using AutoMapper.QueryableExtensions;
using FoodSupplementsSystem.Models.AllBrands;
using FoodSupplementsSystem.Models.AllCategories;
using FoodSupplementsSystem.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    public class HomeController : Controller
    {
        private ICategoriesService categories;

        private IBrandsService brands;

        private ISupplementsService supplements;

        public HomeController(ICategoriesService categories, IBrandsService brands, ISupplementsService supplements)
        {
            this.categories = categories;
            this.brands = brands;
            this.supplements = supplements;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult TopBrands()
        {
            var resultBrands = this.brands.GetAll().Take(3).ProjectTo<BrandViewModel>().ToList(); ;

            return PartialView("_TopBrands", resultBrands);
        }

        [ChildActionOnly]
        public ActionResult TopCategories()
        {
            var resultCategories = this.categories.GetAll().Take(3).ProjectTo<CategoryViewModel>().ToList(); ;

            return PartialView("_TopCategories", resultCategories);
        }

        [ChildActionOnly]
        public ActionResult TopSupplements()
        {
            var resultSupplements = this.supplements.GetAll().Take(3).ProjectTo<SupplementViewModel>().ToList(); ;

            return PartialView("_TopSupplements", resultSupplements);
        }
    }
}
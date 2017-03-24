using AutoMapper.QueryableExtensions;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Models.AllBrands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllBrandsController : Controller
    {
        private IRepository<Brand> brandsWrapper;

        public AllBrandsController(IRepository<Brand> brandsWrapper)
        {
            this.brandsWrapper = brandsWrapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IQueryable<Brand> brands = brandsWrapper.All();

            var resultBrands = brands.ProjectTo<BrandViewModel>().ToList();

            return View(resultBrands);
        }
    }
}
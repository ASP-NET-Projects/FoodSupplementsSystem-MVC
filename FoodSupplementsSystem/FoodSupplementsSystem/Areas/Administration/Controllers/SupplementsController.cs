﻿using System;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupplementsController : UserController
    {
        private ISupplementsService supplements;
        private IDropDownListPopulator populator;

        public SupplementsController(ISupplementsService supplements, IDropDownListPopulator populator, IEfGenericRepository<ApplicationUser> repoUser)
            : base(repoUser)
        {
            this.supplements = supplements;
            this.populator = populator;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var addSupplementViewModel = new AddSupplementViewModel
            {
                Categories = this.populator.GetCategories(),
                Topics = this.populator.GetTopics(),
                Brands = this.populator.GetBrands()
            };

            return View(addSupplementViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddSupplementViewModel supplement)
        {
            if (supplement != null && ModelState.IsValid)
            {
                var dbSupplement = Mapper.Map<Supplement>(supplement);
                dbSupplement.CreationDate = DateTime.UtcNow;
                dbSupplement.Author = this.UserProfile;

                this.supplements.Create(dbSupplement);

                return RedirectToAction("Index", "Supplements");
            }

            supplement.Categories = this.populator.GetCategories();
            supplement.Brands = this.populator.GetBrands();
            supplement.Topics = this.populator.GetTopics();

            return View(supplement);
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
    }
}

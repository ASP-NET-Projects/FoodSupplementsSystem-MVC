using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;
using Kendo.Mvc.UI;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Categories;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.CategoriesControllerTests
{
    [TestFixture]
    public class Categories_Create_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<Supplement, SupplementViewModel>();
                cfg.CreateMap<SupplementViewModel, Supplement>();
            });
        }

        [Test]
        public void ReturnJsonResult_WhenGetToCategories_Create()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categoryViewModel = DataHelper.GetAdminCategoryViewModel();
            var kendoDataRequest = new DataSourceRequest();

            categoriesService.Setup(x => x.Create(It.IsAny<Category>())).Verifiable();

            var controller = new CategoriesController(categoriesService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Categories_Create(kendoDataRequest, categoryViewModel)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToCategories_Create()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categoryViewModel = DataHelper.GetAdminCategoryViewModel();
            var kendoDataRequest = new DataSourceRequest();

            categoriesService.Setup(x => x.Create(It.IsAny<Category>())).Verifiable();

            var controller = new CategoriesController(categoriesService.Object);

            //Act
            var controllerResult = controller.Categories_Create(kendoDataRequest, categoryViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<CategoryViewModel>;

            //Assert
            Assert.IsInstanceOf<IEnumerable<CategoryViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToCategories_Create()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categoryViewModel = DataHelper.GetAdminCategoryViewModel();
            var kendoDataRequest = new DataSourceRequest();

            categoriesService.Setup(x => x.Create(It.IsAny<Category>())).Verifiable();

            var controller = new CategoriesController(categoriesService.Object);

            //Act
            var controllerResult = controller.Categories_Create(kendoDataRequest, categoryViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<CategoryViewModel>;

            //Assert
            Assert.AreEqual(categoryViewModel, results.FirstOrDefault());
            Assert.AreEqual(categoryViewModel.Id, results.FirstOrDefault().Id);
            Assert.AreEqual(categoryViewModel.Name, results.FirstOrDefault().Name);
        }
    }
}

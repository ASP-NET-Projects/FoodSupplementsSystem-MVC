using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;
using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Categories;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.CategoriesControllerTests
{
    [TestFixture]
    public class Categories_Read_Should
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
        public void ReturnJsonResult_WhenGetToCategories_Read()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categories = DataHelper.GetCategories();
            var kendoDataRequest = new DataSourceRequest();

            categoriesService.Setup(x => x.GetAll()).Returns(categories);

            var controller = new CategoriesController(categoriesService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Categories_Read(kendoDataRequest)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToCategories_Read()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categories = DataHelper.GetCategories();
            var kendoDataRequest = new DataSourceRequest();

            categoriesService.Setup(x => x.GetAll()).Returns(categories);

            var controller = new CategoriesController(categoriesService.Object);

            //Act
            var controllerResult = controller.Categories_Read(kendoDataRequest);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<CategoryViewModel>;

            //Assert
            Assert.IsInstanceOf<IList<CategoryViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToCategories_Read()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categories = DataHelper.GetCategories();
            var kendoDataRequest = new DataSourceRequest();
        
            categoriesService.Setup(x => x.GetAll()).Returns(categories);
        
            var controller = new CategoriesController(categoriesService.Object);
        
            //Act
            var controllerResult = controller.Categories_Read(kendoDataRequest);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<CategoryViewModel>;
        
            var expectedResult = Mapper.Map<List<CategoryViewModel>>(categories);
        
            //Assert
            Assert.AreEqual(expectedResult.FirstOrDefault().Id, results.FirstOrDefault().Id);
            Assert.AreEqual(expectedResult.FirstOrDefault().Name, results.FirstOrDefault().Name);
        }
    }
}

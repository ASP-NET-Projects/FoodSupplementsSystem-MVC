using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Categories;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.CategoriesControllerTests
{
    [TestFixture]
    public class Categories_Destroy_Should
    {
        [Test]
        public void ReturnJsonResult_WhenGetToCategories_Destroy()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categoryViewModel = DataHelper.GetAdminCategoryViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            categoriesService.Setup(x => x.Delete(It.IsAny<Category>())).Verifiable();

            var controller = new CategoriesController(categoriesService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Categories_Destroy(kendoDataRequest, categoryViewModel)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToCategories_Destroy()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categoryViewModel = DataHelper.GetAdminCategoryViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            categoriesService.Setup(x => x.Delete(It.IsAny<Category>())).Verifiable();

            var controller = new CategoriesController(categoriesService.Object);

            //Act
            var controllerResult = controller.Categories_Destroy(kendoDataRequest, categoryViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<CategoryViewModel>;

            //Assert
            Assert.IsInstanceOf<IEnumerable<CategoryViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToCategories_Destroy()
        {
            //Arrange
            var categoriesService = new Mock<ICategoriesService>();
            var categoryViewModel = DataHelper.GetAdminCategoryViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            categoriesService.Setup(x => x.Delete(It.IsAny<Category>())).Verifiable();

            var controller = new CategoriesController(categoriesService.Object);

            //Act
            var controllerResult = controller.Categories_Destroy(kendoDataRequest, categoryViewModel);
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

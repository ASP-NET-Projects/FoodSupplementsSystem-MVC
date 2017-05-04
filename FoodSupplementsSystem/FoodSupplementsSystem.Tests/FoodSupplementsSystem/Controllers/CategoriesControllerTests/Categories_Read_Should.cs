using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Kendo.Mvc.UI;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Categories;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.CategoriesControllerTests
{
    [TestFixture]
    public class Categories_Read_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull_test()
        {
            //Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var categories = GetCategories();
            categoriesServiceMock.Setup(x => x.GetAll())
                .Returns(categories.AsQueryable());
            AutoMapperConfig.Config();
            var controller = new CategoriesController(categoriesServiceMock.Object);
            var kendoDataRequest = new DataSourceRequest();

            //Act
            var controllerResult = controller.Categories_Read(kendoDataRequest);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as List<CategoryViewModel>;

            //Assert
            Assert.IsInstanceOf<List<CategoryViewModel>>(results);
        }

        private IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new Category()
                {
                    Id = i,
                    Name = "category" + i
                });
            }

            return categories;
        }
    }
}

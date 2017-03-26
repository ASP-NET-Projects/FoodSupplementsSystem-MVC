using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.HomeControllerTests
{
    [TestFixture]
    public class TopCategories_Should
    {
        [Test]
        public void ReturnPartialView_WhenGetToTopCategories()
        {
            // Arrange
            var brandsServiceMock = new Mock<IBrandsService>();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var categories = GetCategories();

            categoriesServiceMock.Setup(x => x.GetAll())
                .Returns(categories.AsQueryable());

            var supplementsServiceMock = new Mock<ISupplementsService>();

            AutoMapperConfig.Config();

            var controller = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.TopCategories())
                .ShouldRenderPartialView("_TopCategories");
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

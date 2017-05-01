using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Services.Data.Contracts;

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
            var homeServiceMock = new Mock<IHomeService>();

            AutoMapperConfig.Config();

            var controller = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object, homeServiceMock.Object);

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

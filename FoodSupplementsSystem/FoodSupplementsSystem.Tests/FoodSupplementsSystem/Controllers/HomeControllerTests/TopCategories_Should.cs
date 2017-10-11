using System.Linq;

using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Services.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.HomeControllerTests
{
    [TestFixture]
    public class TopCategories_Should
    {
        [Test]
        public void ReturnPartialView_WhenGetToTopCategories()
        {
            // Arrange
            var homeService = new Mock<IHomeService>();
            var categoriesLast3 = DataHelper.GetCommonCategoriesCollection().Take(3).ToList();
            homeService.Setup(x => x.GetLastCategories()).Returns(categoriesLast3);

            AutoMapperConfig.Config();

            var controller = new HomeController(homeService.Object);

            // Act & Assert
            controller.WithCallTo(c => c.TopCategories())
                .ShouldRenderPartialView("_TopCategories");
        }
    }
}

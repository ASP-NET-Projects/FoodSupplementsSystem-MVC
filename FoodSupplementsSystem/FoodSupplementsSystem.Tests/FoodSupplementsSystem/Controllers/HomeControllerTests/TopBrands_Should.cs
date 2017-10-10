using System.Linq;

using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.HomeControllerTests
{
    [TestFixture]
    public class TopBrands_Should
    {
        [Test]
        public void ReturnPartialView_WhenGetToTopBrands()
        {
            // Arrange
            var homeService = new Mock<IHomeService>();
            var brandsLast3 = DataHelper.GetCommonBrandsCollection().Take(3).ToList();
            homeService.Setup(x => x.GetLastBrands()).Returns(brandsLast3);

            AutoMapperConfig.Config();

            var controller = new HomeController(homeService.Object);

            // Act & Assert
            controller.WithCallTo(c => c.TopBrands())
                .ShouldRenderPartialView("_TopBrands");
        }
    }
}

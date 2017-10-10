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
    public class TopSupplements_Should
    {
        [Test]
        public void ReturnPartialView_WhenGetToTopSupplements()
        {
            // Arrange
            var homeService = new Mock<IHomeService>();
            var supplementsLast3 = DataHelper.GetCommonSupplementsCollection().Take(3).ToList();
            homeService.Setup(x => x.GetLastSupplements()).Returns(supplementsLast3);

            AutoMapperConfig.Config();

            var controller = new HomeController(homeService.Object);

            // Act & Assert
            controller.WithCallTo(c => c.TopSupplements())
                .ShouldRenderPartialView("_TopSupplements");
        }
    }
}

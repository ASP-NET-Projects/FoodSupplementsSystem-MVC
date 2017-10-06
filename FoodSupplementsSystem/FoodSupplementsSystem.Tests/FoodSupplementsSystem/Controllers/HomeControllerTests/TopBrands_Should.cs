using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Services.Data.Contracts;
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
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var brandsServiceMock = new Mock<IBrandsService>();

            var brands = DataHelper.GetBrands();

            brandsServiceMock.Setup(x => x.GetAll())
                .Returns(brands);

            var supplementsServiceMock = new Mock<ISupplementsService>();
            var homeServiceMock = new Mock<IHomeService>();

            AutoMapperConfig.Config();

            var controller = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object, homeServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.TopBrands())
                .ShouldRenderPartialView("_TopBrands");
        }
    }
}

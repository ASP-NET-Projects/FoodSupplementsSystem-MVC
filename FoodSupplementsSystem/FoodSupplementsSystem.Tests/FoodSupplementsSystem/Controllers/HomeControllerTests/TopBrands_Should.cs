using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

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

            var brands = GetBrands();

            brandsServiceMock.Setup(x => x.GetAll())
                .Returns(brands.AsQueryable());

            var supplementsServiceMock = new Mock<ISupplementsService>();
            var homeServiceMock = new Mock<IHomeService>();

            AutoMapperConfig.Config();

            var controller = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object, homeServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.TopBrands())
                .ShouldRenderPartialView("_TopBrands");
        }

        private IEnumerable<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();

            for (int i = 1; i <= 10; i++)
            {
                brands.Add(new Brand()
                {
                    Id = i,
                    Name = "category" + i,
                    WebSite = "website" + i
                });
            }

            return brands;
        }
    }
}

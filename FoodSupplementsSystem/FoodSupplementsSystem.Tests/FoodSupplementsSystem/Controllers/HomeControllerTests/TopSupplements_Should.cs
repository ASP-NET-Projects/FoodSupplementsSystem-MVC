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
    public class TopSupplements_Should
    {
        [Test]
        public void ReturnPartialView_WhenGetToTopSupplements()
        {
            // Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var brandsServiceMock = new Mock<IBrandsService>();
            var supplementsServiceMock = new Mock<ISupplementsService>();

            var supplements = GetSupplements();

            supplementsServiceMock.Setup(x => x.GetAll())
                .Returns(supplements.AsQueryable());

            var homeServiceMock = new Mock<IHomeService>();

            AutoMapperConfig.Config();

            var controller = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object, homeServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.TopBrands())
                .ShouldRenderPartialView("_TopBrands");
        }

        private IEnumerable<Supplement> GetSupplements()
        {
            List<Supplement> supplements = new List<Supplement>();

            for (int i = 1; i <= 10; i++)
            {
                supplements.Add(new Supplement()
                {
                    Id = i,
                    Name = "supplement" + i,
                    ImageUrl = "imageUrl" + i
                });
            }

            return supplements;
        }
    }
}

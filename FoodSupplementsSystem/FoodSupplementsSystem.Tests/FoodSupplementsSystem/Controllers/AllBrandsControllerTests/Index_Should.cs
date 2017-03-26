using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllBrandsControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void RunDefaultView_WhenGetToIndex()
        {
            // Arrange
            var brandsServiceMock = new Mock<IBrandsService>();
            var categories = GetBrands();

            brandsServiceMock.Setup(x => x.GetAll())
                .Returns(categories.AsQueryable());

            AutoMapperConfig.Config();

            var controller = new AllBrandsController(brandsServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        private IEnumerable<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();

            for (int i = 1; i <= 10; i++)
            {
                brands.Add(new Brand()
                {
                    Id = i,
                    Name = "brand" + i,
                    WebSite = "website" + i
                });
            }

            return brands;
        }
    }
}

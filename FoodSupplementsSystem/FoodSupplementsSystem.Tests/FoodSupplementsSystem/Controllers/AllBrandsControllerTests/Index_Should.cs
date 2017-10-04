using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Web.Mvc;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;
using AutoMapper.QueryableExtensions;

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
            var brands = GetBrands();

            brandsServiceMock.Setup(x => x.GetAll())
                .Returns(brands.AsQueryable());

            AutoMapperConfig.Config();

            var controller = new AllBrandsController(brandsServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void Test()
        {
            //Arrange
            var brandsServiceMock = new Mock<IBrandsService>();
            var brands = GetBrands();

            brandsServiceMock.Setup(s=>s.GetAll()).Returns(brands.AsQueryable());

            AutoMapperConfig.Config();

            var brandsController = new AllBrandsController(brandsServiceMock.Object);

            //Act
            //var result = brandsController.Index() as ViewResult;

            //Assert
            brandsController.WithCallTo(c => c.Index()).ShouldRenderView("Index")
                .WithModel<List<BrandViewModel>>();

        }

        private IEnumerable<Brand> GetBrands()
        {
            var brands = new List<Brand>();

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

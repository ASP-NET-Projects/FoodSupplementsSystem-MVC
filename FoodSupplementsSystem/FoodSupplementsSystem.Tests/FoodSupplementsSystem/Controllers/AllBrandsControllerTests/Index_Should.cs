using System.Collections.Generic;
using System.Linq;

using AutoMapper.QueryableExtensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.Tests.DataHelpers;

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
            var brands = DataHelper.GetBrands();

            brandsServiceMock.Setup(x => x.GetAll())
                .Returns(brands);

            AutoMapperConfig.Config();

            var controller = new AllBrandsController(brandsServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnCorrectModelType_WhenGetToIndex()
        {
            //Arrange
            var brandsServiceMock = new Mock<IBrandsService>();
            var brands = DataHelper.GetBrands();

            brandsServiceMock.Setup(s => s.GetAll()).Returns(brands);

            AutoMapperConfig.Config();

            var brandsController = new AllBrandsController(brandsServiceMock.Object);

            //Act & Assert
            brandsController.WithCallTo(c => c.Index()).ShouldRenderView("Index").WithModel<List<BrandViewModel>>();
        }

        [Test]
        public void ReturnCorrectResultModel_WhenGetToIndex()
        {
            //Arrange
            var brandsServiceMock = new Mock<IBrandsService>();
            var brands = DataHelper.GetBrands();

            brandsServiceMock.Setup(s => s.GetAll()).Returns(brands);

            AutoMapperConfig.Config();

            var brandsController = new AllBrandsController(brandsServiceMock.Object);
            var expectedResult = brands.ProjectTo<BrandViewModel>().ToList();

            //Act & Assert
            brandsController.WithCallTo(c => c.Index()).ShouldRenderView("Index")
                .WithModel<IList<BrandViewModel>>(x =>
               {
                   Assert.AreEqual(x.FirstOrDefault().Id, expectedResult.FirstOrDefault().Id);
                   Assert.AreEqual(x.FirstOrDefault().Name, expectedResult.FirstOrDefault().Name);
                   Assert.AreEqual(x.FirstOrDefault().WebSite, expectedResult.FirstOrDefault().WebSite);
               });
        }
    }
}

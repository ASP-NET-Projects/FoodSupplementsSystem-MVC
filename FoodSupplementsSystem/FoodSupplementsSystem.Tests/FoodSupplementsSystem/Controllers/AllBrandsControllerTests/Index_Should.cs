using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllBrandsControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg=>
            {
                cfg.CreateMap<Brand, BrandViewModel>();
                cfg.CreateMap<BrandViewModel, Brand>();
                cfg.CreateMap<Supplement, SupplementViewModel>();
                cfg.CreateMap<SupplementViewModel, Supplement>();
            });
        }

        [Test]
        public void RunDefaultView_WhenGetToIndex()
        {
            // Arrange
            var brandsServiceMock = new Mock<IBrandsService>();
            var brands = DataHelper.GetBrands();

            brandsServiceMock.Setup(x => x.GetAll())
                .Returns(brands);

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

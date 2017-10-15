using System.Collections.Generic;
using System.Web.Mvc;

using AutoMapper;
using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.BrandsControllerTests
{
    [TestFixture]
    public class Brands_Read_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Brand, BrandViewModel>();
                cfg.CreateMap<BrandViewModel, Brand>();
                cfg.CreateMap<Supplement, SupplementViewModel>();
                cfg.CreateMap<SupplementViewModel, Supplement>();
            });
        }

        [Test]
        public void ReturnJsonResult_WhenGetToBrands_Read()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brands = DataHelper.GetBrands();
            var kendoDataRequest = new DataSourceRequest();

            brandsService.Setup(x => x.GetAll()).Returns(brands);

            var controller = new BrandsController(brandsService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Brands_Read(kendoDataRequest)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToBrands_Read()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brands = DataHelper.GetBrands();
            var kendoDataRequest = new DataSourceRequest();

            brandsService.Setup(x => x.GetAll()).Returns(brands);

            var controller = new BrandsController(brandsService.Object);

            //Act
            var controllerResult = controller.Brands_Read(kendoDataRequest);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<BrandViewModel>;

            //Assert
            Assert.IsInstanceOf<IList<BrandViewModel>>(results);
        }
    }
}

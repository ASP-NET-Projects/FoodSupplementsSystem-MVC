﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;
using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.BrandsControllerTests
{
    [TestFixture]
    public class Brands_Create_Should
    {
        [Test]
        public void ReturnJsonResult_WhenGetToBrands_Create()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brandViewModel = DataHelper.GetAdminBrandViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            var brandDbModel = Mapper.Map<Brand>(brandViewModel);
            brandsService.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(brandDbModel);

            var controller = new BrandsController(brandsService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Brands_Create(kendoDataRequest, brandViewModel)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToBrands_Create()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brandViewModel = DataHelper.GetAdminBrandViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            var brandDbModel = Mapper.Map<Brand>(brandViewModel);
            brandsService.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(brandDbModel);

            var controller = new BrandsController(brandsService.Object);

            //Act
            var controllerResult = controller.Brands_Create(kendoDataRequest, brandViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<BrandViewModel>;

            //Assert
            Assert.IsInstanceOf<IEnumerable<BrandViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToBrands_Create()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brandViewModel = DataHelper.GetAdminBrandViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            var brandDbModel = Mapper.Map<Brand>(brandViewModel);
            brandsService.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(brandDbModel);

            var controller = new BrandsController(brandsService.Object);

            //Act
            var controllerResult = controller.Brands_Create(kendoDataRequest, brandViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<BrandViewModel>;

            //Assert
            Assert.AreEqual(brandViewModel, results.FirstOrDefault());
            Assert.AreEqual(brandViewModel.Id, results.FirstOrDefault().Id);
            Assert.AreEqual(brandViewModel.Name, results.FirstOrDefault().Name);
        }
    }
}

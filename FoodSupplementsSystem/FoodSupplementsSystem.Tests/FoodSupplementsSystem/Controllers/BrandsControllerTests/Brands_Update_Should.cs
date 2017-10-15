using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;
using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.BrandsControllerTests
{
    [TestFixture]
    public class Brands_Update_Should
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
        public void ReturnJsonResult_WhenGetToBrands_Update()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brandViewModel = DataHelper.GetAdminBrandViewModel();
            var kendoDataRequest = new DataSourceRequest();

            brandsService.Setup(x => x.Update(It.IsAny<Brand>())).Verifiable();

            var controller = new BrandsController(brandsService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Brands_Update(kendoDataRequest, brandViewModel)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToBrands_Update()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brandViewModel = DataHelper.GetAdminBrandViewModel();
            var kendoDataRequest = new DataSourceRequest();

            brandsService.Setup(x => x.Update(It.IsAny<Brand>())).Verifiable();

            var controller = new BrandsController(brandsService.Object);

            //Act
            var controllerResult = controller.Brands_Update(kendoDataRequest, brandViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<BrandViewModel>;

            //Assert
            Assert.IsInstanceOf<IEnumerable<BrandViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToBrands_Update()
        {
            //Arrange
            var brandsService = new Mock<IBrandsService>();
            var brandViewModel = DataHelper.GetAdminBrandViewModel();
            var kendoDataRequest = new DataSourceRequest();

            brandsService.Setup(x => x.Update(It.IsAny<Brand>())).Verifiable();

            var controller = new BrandsController(brandsService.Object);

            //Act
            var controllerResult = controller.Brands_Update(kendoDataRequest, brandViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<BrandViewModel>;

            //Assert
            Assert.AreEqual(brandViewModel, results.FirstOrDefault());
            Assert.AreEqual(brandViewModel.Id, results.FirstOrDefault().Id);
            Assert.AreEqual(brandViewModel.Name, results.FirstOrDefault().Name);
            Assert.AreEqual(brandViewModel.WebSite, results.FirstOrDefault().WebSite);
        }
    }
}

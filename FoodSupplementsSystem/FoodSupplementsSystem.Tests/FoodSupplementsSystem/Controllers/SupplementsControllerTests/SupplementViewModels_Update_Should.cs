using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.SupplementsControllerTests
{
    [TestFixture]
    public class SupplementViewModels_Update_Should
    {
        [Test]
        public void ReturnJsonResult_WhenGetToSupplementViewModels_Update()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var supplementViewModel = DataHelper.GetAdminSupplementViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            supplementsService.Setup(x => x.Update(It.IsAny<Supplement>())).Verifiable();

            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);

            //Act & Assert
            controller.WithCallTo(c => c.SupplementViewModels_Update(kendoDataRequest, supplementViewModel)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToSupplementViewModels_Update()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var supplementViewModel = DataHelper.GetAdminSupplementViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            supplementsService.Setup(x => x.Update(It.IsAny<Supplement>())).Verifiable();

            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);

            //Act
            var controllerResult = controller.SupplementViewModels_Update(kendoDataRequest, supplementViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<SupplementViewModel>;

            //Assert
            Assert.IsInstanceOf<IEnumerable<SupplementViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToSupplementViewModels_Update()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var supplementViewModel = DataHelper.GetAdminSupplementViewModel();
            var kendoDataRequest = new DataSourceRequest();

            AutoMapperConfig.Config();

            supplementsService.Setup(x => x.Update(It.IsAny<Supplement>())).Verifiable();

            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);

            //Act
            var controllerResult = controller.SupplementViewModels_Update(kendoDataRequest, supplementViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<SupplementViewModel>;

            //Assert
            Assert.AreEqual(supplementViewModel, results.FirstOrDefault());
            Assert.AreEqual(supplementViewModel.Id, results.FirstOrDefault().Id);
            Assert.AreEqual(supplementViewModel.Name, results.FirstOrDefault().Name);
            Assert.AreEqual(supplementViewModel.ImageUrl, results.FirstOrDefault().ImageUrl);
            Assert.AreEqual(supplementViewModel.Ingredients, results.FirstOrDefault().Ingredients);
            Assert.AreEqual(supplementViewModel.Use, results.FirstOrDefault().Use);
            Assert.AreEqual(supplementViewModel.Description, results.FirstOrDefault().Description);
        }
    }
}

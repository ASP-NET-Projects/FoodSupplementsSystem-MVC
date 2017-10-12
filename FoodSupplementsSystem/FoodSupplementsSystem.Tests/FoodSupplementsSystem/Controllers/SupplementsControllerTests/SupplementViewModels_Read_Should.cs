using System.Collections.Generic;
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
    public class SupplementViewModels_Read_Should
    {
       [Test]
       public void ReturnJsonResult_WhenGetToSupplementViewModels_Read()
       {
           //Arrange
           var supplementsService = new Mock<ISupplementsService>();
           var dropDownListPopulator = new Mock<IDropDownListPopulator>();
           var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
           var supplements = DataHelper.GetSupplements();
           var kendoDataRequest = new DataSourceRequest();
       
           supplementsService.Setup(x => x.GetAll()).Returns(supplements);
       
           AutoMapperConfig.Config();
       
           var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);
       
           //Act & Assert
           controller.WithCallTo(c => c.SupplementViewModels_Read(kendoDataRequest)).ShouldReturnJson();
       }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToSupplementViewModels_Read()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var supplements = DataHelper.GetSupplements();
            var kendoDataRequest = new DataSourceRequest();
        
            supplementsService.Setup(x => x.GetAll()).Returns(supplements);
        
            AutoMapperConfig.Config();
        
            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);
        
            //Act
            var controllerResult = controller.SupplementViewModels_Read(kendoDataRequest);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<SupplementViewModel>;
        
            //Assert
            Assert.IsInstanceOf<IList<SupplementViewModel>>(results);
        }
    }
}

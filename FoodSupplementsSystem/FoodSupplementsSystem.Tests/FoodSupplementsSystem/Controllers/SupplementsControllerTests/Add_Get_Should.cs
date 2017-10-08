using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.SupplementsControllerTests
{
    [TestFixture]
    public class Add_Get_Should
    {
        [Test]
        public void RunDefaultView_WhenGetToAdd()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();

            AutoMapperConfig.Config();

            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Add()).ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnCorrectModelType_WhenGetToAll()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();

            AutoMapperConfig.Config();

            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Add()).ShouldRenderView("Add").WithModel<AddSupplementViewModel>();
        }
    }
}

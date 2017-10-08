using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.SupplementsControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView_WhenGetToIndex()
        {
            // Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();

            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);

            // Act && Assert
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }
    }
}

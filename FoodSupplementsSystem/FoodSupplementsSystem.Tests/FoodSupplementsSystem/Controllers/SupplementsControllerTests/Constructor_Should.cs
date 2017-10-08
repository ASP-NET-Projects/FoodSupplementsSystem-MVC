using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.SupplementsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameteraAreNotNull()
        {
            // Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();

            // Act
            var controller = new SupplementsController(supplementsService.Object, dropDownListPopulator.Object, repoUser.Object);

            // Assert
            Assert.IsInstanceOf<SupplementsController>(controller);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SupplementsController(null, null, null));
        }
    }
}

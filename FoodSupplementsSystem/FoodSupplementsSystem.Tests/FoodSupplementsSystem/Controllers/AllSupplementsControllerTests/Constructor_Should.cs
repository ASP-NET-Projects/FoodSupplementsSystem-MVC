using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllSupplementsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();

            // Act
            var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            // Assert
            Assert.IsInstanceOf<AllSupplementsController>(supplementsController);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllSupplementsController(null, null));
        }
    }
}

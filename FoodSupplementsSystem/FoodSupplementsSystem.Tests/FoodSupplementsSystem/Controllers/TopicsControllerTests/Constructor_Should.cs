using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.TopicsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var topicsService = new Mock<ITopicsService>();

            // Act
            var controller = new TopicsController(topicsService.Object);

            // Assert
            Assert.IsInstanceOf<TopicsController>(controller);
        }

        [Test]
        public void ThrowException_WhenParameterIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TopicsController(null));
        }
    }
}

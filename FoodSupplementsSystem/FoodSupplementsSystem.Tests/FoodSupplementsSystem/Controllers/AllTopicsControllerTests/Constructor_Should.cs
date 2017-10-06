using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllTopicsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var topicsServiceMock = new Mock<ITopicsService>();
            var commentsServiceMock = new Mock<ICommentsService>();

            // Act
            AllTopicsController topicsController = new AllTopicsController(topicsServiceMock.Object, commentsServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<AllTopicsController>(topicsController);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllTopicsController(null, null));
        }
    }
}

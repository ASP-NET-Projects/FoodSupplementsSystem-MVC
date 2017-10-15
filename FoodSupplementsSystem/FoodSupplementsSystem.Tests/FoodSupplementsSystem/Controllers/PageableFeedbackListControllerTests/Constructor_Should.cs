using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.PageableFeedbackListControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var feedbacksService = new Mock<IFeedbacksService>();

            // Act
            var controller = new PageableFeedbackListController(feedbacksService.Object);

            // Assert
            Assert.IsInstanceOf<PageableFeedbackListController>(controller);
        }

        [Test]
        public void ThrowException_WhenParameterIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PageableFeedbackListController(null));
        }
    }
}

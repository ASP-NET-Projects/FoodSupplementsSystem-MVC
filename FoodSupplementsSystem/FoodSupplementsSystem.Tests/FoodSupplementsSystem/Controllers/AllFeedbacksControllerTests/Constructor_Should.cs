using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllFeedbacksControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var feedbacksService = new Mock<IFeedbacksService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var controller = new AllFeedbacksController(feedbacksService.Object, repoUser.Object);

            //Act & Assert
            Assert.IsInstanceOf<AllFeedbacksController>(controller);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            //Arrange
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllFeedbacksController(null, repoUser.Object));
        }
    }
}

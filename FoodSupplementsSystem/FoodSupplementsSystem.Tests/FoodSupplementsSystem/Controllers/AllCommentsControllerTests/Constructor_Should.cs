using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllCommentsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var topics = new Mock<ITopicsService>();
            var comments=new Mock<ICommentsService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();

            var controller = new AllCommentsController(topics.Object, comments.Object, repoUser.Object);

            //Act & Assert
            Assert.IsInstanceOf<AllCommentsController>(controller);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            //Arrange
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllCommentsController(null, null, repoUser.Object));
        }
    }
}

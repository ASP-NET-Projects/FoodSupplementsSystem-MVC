using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllFeedbacksControllerTests
{
    [TestFixture]
    public class CreateGet_Should
    {
        [Test]
        public void RunDefaultView_WhenGetToCreate()
        {
            // Arrange
            var feedbacksService = new Mock<IFeedbacksService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var controller = new AllFeedbacksController(feedbacksService.Object, repoUser.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Create()).ShouldRenderDefaultView();
        }
    }
}

using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllFeedbacksControllerTests
{
    [TestFixture]
    public class CreatePost_Should
    {
        [Test]
        public void RunDefaultView_WhenModelStateIsNotValid()
        {
            //Arrange
            var feedbacksService = new Mock<IFeedbacksService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var controller = new AllFeedbacksController(feedbacksService.Object, repoUser.Object);
            var feedback = DataHelper.GetFeedbackViewModel();
            controller.ModelState.AddModelError("name", "Invalid name lenght!");

            //Act & Assert
            controller.WithCallTo(c => c.Create(feedback)).ShouldRenderDefaultView();
        }
    }
}

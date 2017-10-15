using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Services.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.HomeControllerTests
{
    [TestFixture]
    public class MostCommentedTopics_Should
    {
        [Test]
        public void ReturnPartialView_WhenGetToMostCommentedTopics()
        {
            // Arrange
            var homeService = new Mock<IHomeService>();
            var topicsCollection = DataHelper.GetHomeTopicViewModelCollection();
            homeService.Setup(x => x.GetTopicViewModel(It.IsAny<int>())).Returns(topicsCollection);

            var controller = new HomeController(homeService.Object);

            // Act & Assert
            controller.WithCallTo(c => c.MostCommentedTopics())
                .ShouldRenderPartialView("_MostCommentedTopicsPartial");
        }
    }
}

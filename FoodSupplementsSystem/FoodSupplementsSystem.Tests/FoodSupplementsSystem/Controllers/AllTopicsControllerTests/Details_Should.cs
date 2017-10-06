using System.Linq;

using AutoMapper.QueryableExtensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllTopics;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllTopicsControllerTests
{
    [TestFixture]
    public class Details_Should
    {
        [Test]
        public void RunDefaultView_WhenGetToDetails_WithValidTopicId()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var commentsService = new Mock<ICommentsService>();
            var topics = DataHelper.GetTopics();
            var topicId = topics.FirstOrDefault().Id;

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            AutoMapperConfig.Config();

            var topicsController = new AllTopicsController(topicsService.Object, commentsService.Object);

            //Act & Assert
            topicsController.WithCallTo(c => c.Details(topicId))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnCorrectModelType_WhenGetToDetails()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var commentsService = new Mock<ICommentsService>();
            var topics = DataHelper.GetTopics();
            var topicId = topics.FirstOrDefault().Id;

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            AutoMapperConfig.Config();

            var topicsController = new AllTopicsController(topicsService.Object, commentsService.Object);

            //Act & Assert
            topicsController.WithCallTo(c => c.Details(topicId)).ShouldRenderView("Details").WithModel<DetailsTopicViewModel>();
        }

        [Test]
        public void ReturnCorrectResultModel_WhenGetToDetails()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var commentsService = new Mock<ICommentsService>();
            var topics = DataHelper.GetTopics();
            var topicId = topics.FirstOrDefault().Id;

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            AutoMapperConfig.Config();

            var topicsController = new AllTopicsController(topicsService.Object, commentsService.Object);
            var expectedResult = topics.ProjectTo<DetailsTopicViewModel>().FirstOrDefault();

            //Act & Assert
            topicsController.WithCallTo(c => c.Details(topicId)).ShouldRenderView("Details")
                .WithModel<DetailsTopicViewModel>(x =>
                {
                    Assert.AreEqual(x.Id, expectedResult.Id);
                    Assert.AreEqual(x.Name, expectedResult.Name);
                    Assert.AreEqual(x.Description, expectedResult.Description);
                });
        }
    }
}

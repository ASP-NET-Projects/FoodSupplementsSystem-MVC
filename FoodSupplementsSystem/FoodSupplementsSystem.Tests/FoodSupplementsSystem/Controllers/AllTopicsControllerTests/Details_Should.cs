using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllTopics;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.ViewModels.AllComments;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllTopicsControllerTests
{
    [TestFixture]
    public class Details_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Topic, DetailsTopicViewModel>();
                cfg.CreateMap<DetailsTopicViewModel, Topic>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<CommentViewModel, Comment>();
            });
        }

        [Test]
        public void RunDefaultView_WhenGetToDetails_WithValidTopicId()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var commentsService = new Mock<ICommentsService>();
            var topics = DataHelper.GetTopics();
            var topicId = topics.FirstOrDefault().Id;

            topicsService.Setup(x => x.GetAll()).Returns(topics);

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

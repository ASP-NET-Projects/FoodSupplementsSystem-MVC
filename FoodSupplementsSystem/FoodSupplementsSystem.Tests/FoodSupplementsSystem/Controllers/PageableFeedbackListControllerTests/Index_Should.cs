using AutoMapper;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Areas.Administration.ViewModels.PageableFeedbackList;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.PageableFeedbackListControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Feedback, FeedbackViewModel>();
                cfg.CreateMap<FeedbackViewModel, Feedback>();
            });
        }

        [Test]
        public void ReturnDefaultView_WhenGetToIndex()
        {
            // Arrange
            var feedbacksService = new Mock<IFeedbacksService>();

            var controller = new PageableFeedbackListController(feedbacksService.Object);

            // Act && Assert
            controller.WithCallTo(c => c.Index(1)).ShouldRenderDefaultView();
        }
    }
}

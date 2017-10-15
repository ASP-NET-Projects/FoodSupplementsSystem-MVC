using System.Web.Mvc;

using AutoMapper;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllFeedbacks;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllFeedbacksControllerTests
{
    [TestFixture]
    public class CreatePost_Should
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

        [Test]
        public void ReturnCorrectModelInstance_WhenModelStateIsNotValid()
        {
            //Arrange
            var feedbacksService = new Mock<IFeedbacksService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var feedback = DataHelper.GetFeedbackViewModel();

            var controller = new AllFeedbacksController(feedbacksService.Object, repoUser.Object);
            controller.ModelState.AddModelError("name", "Invalid name lenght!");

            //Act & Assert
            controller.WithCallTo(c => c.Create(feedback)).ShouldRenderView("Create").WithModel<FeedbackViewModel>();
        }

        [Test]
        public void RedirectToHome_WhenModelStateIsValid()
        {
            //Arrange
            var feedbacksService = new Mock<IFeedbacksService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var feedback = DataHelper.GetFeedbackViewModel();
            feedbacksService.Setup(x => x.Create(It.IsAny<Feedback>())).Verifiable();

            var controller = new AllFeedbacksController(feedbacksService.Object, repoUser.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Create(feedback)).ShouldRedirectTo("/");
        }

        [Test]
        public void AddMessageToTempData_WhenModelStateIsValid()
        {
            //Arrange
            var feedbacksService = new Mock<IFeedbacksService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var feedback = DataHelper.GetFeedbackViewModel();
            feedbacksService.Setup(x => x.Create(It.IsAny<Feedback>())).Verifiable();

            var controller = new AllFeedbacksController(feedbacksService.Object, repoUser.Object);

            //Act
            var result = controller.Create(feedback) as ActionResult;
            
            //Assert
            Assert.AreEqual(controller.TempData["Notification"].ToString(), "Thank you for your feedback!");
        }
    }
}

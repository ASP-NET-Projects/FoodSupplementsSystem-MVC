using AutoMapper;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllComments;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllCommentsControllerTests
{
    [TestFixture]
    public class PostComment_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<CommentViewModel, Comment>();
                cfg.CreateMap<Comment, PostCommentViewModel>();
                cfg.CreateMap<PostCommentViewModel, Comment>();
            });
        }

        [Test]
        public void RenderCorrectPartialView_WhenParametersAreValid()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var comments = new Mock<ICommentsService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var dbTopic = DataHelper.GetTopic();
            var comment = DataHelper.GetPostCommentViewModel();
            comments.Setup(x => x.Create(It.IsAny<Comment>())).Verifiable();
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(dbTopic);

            var controller = new AllCommentsController(topics.Object, comments.Object, repoUser.Object);

            //Act

            //Assert
            controller.WithCallTo(c => c.PostComment(comment)).ShouldRenderPartialView("_CommentPartial");
        }

        [Test]
        public void ReturnCorrectModelInstance_WhenParametersAreValid()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var comments = new Mock<ICommentsService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var dbTopic = DataHelper.GetTopic();
            var comment = DataHelper.GetPostCommentViewModel();
            comments.Setup(x => x.Create(It.IsAny<Comment>())).Verifiable();
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(dbTopic);

            var controller = new AllCommentsController(topics.Object, comments.Object, repoUser.Object);

            //Act

            //Assert
            controller.WithCallTo(c => c.PostComment(comment)).ShouldRenderPartialView("_CommentPartial")
                .WithModel<CommentViewModel>();
        }

        [Test]
        public void ReturnCorrectModel_WhenParametersAreValid()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var comments = new Mock<ICommentsService>();
            var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
            var dbTopic = DataHelper.GetTopic();
            var comment = DataHelper.GetPostCommentViewModel();
            comments.Setup(x => x.Create(It.IsAny<Comment>())).Verifiable();
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(dbTopic);

            var controller = new AllCommentsController(topics.Object, comments.Object, repoUser.Object);
            var dbComment = Mapper.Map<Comment>(comment);
            var expectedComment = Mapper.Map<CommentViewModel>(dbComment);

            //Assert
            controller.WithCallTo(c => c.PostComment(comment)).ShouldRenderPartialView("_CommentPartial")
                .WithModel<CommentViewModel>(x =>
                {
                    Assert.AreEqual(x.Id, expectedComment.Id);
                    Assert.AreEqual(x.Content, expectedComment.Content);
                });
        }

        //[Test]
        //public void ThrowHttpException_WhenModelStateIsNotValid()
        //{
        //    //Arrange
        //    var topics = new Mock<ITopicsService>();
        //    var comments = new Mock<ICommentsService>();
        //    var repoUser = new Mock<IEfGenericRepository<ApplicationUser>>();
        //    var comment = DataHelper.GetPostCommentViewModel();
        //    var controller = new AllCommentsController(topics.Object, comments.Object, repoUser.Object);
        //    controller.ModelState.AddModelError("Content", "It is inavlid content");
        //
        //    //Act
        //    var result = controller.PostComment(comment);
        //
        //    //Assert
        //    Assert.Throws<HttpException>(() =>
        //        controller.PostComment(
        //            comment));
        //    //controller.WithCallTo(c => c.PostComment(comment)).ShouldGiveHttpStatus(new HttpException(400, "Invalid comment").GetHttpCode());
        //}

    }
}

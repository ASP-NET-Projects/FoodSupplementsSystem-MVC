﻿using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllTopics;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.ViewModels.AllSupplements;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllTopicsControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Topic, TopicViewModel>();
                cfg.CreateMap<TopicViewModel, Topic>();
                cfg.CreateMap<Supplement, SupplementViewModel>();
                cfg.CreateMap<SupplementViewModel, Supplement>();
            });
        }

        [Test]
        public void RunDefaultView_WhenGetToIndex()
        {
            // Arrange
            var topicsService = new Mock<ITopicsService>();
            var commentsService = new Mock<ICommentsService>();
            var topics = DataHelper.GetTopics();

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            var topicsController = new AllTopicsController(topicsService.Object, commentsService.Object);

            // Act & Assert
            topicsController.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnCorrectModelType_WhenGetToIndex()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var commentsService = new Mock<ICommentsService>();
            var topics = DataHelper.GetTopics();

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            var topicsController = new AllTopicsController(topicsService.Object, commentsService.Object);

            //Act & Assert
            topicsController.WithCallTo(c => c.Index()).ShouldRenderView("Index").WithModel<List<TopicViewModel>>();
        }

        [Test]
        public void ReturnCorrectResultModel_WhenGetToIndex()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var commentsService = new Mock<ICommentsService>();
            var topics = DataHelper.GetTopics();

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            var topicsController = new AllTopicsController(topicsService.Object, commentsService.Object);
            var expectedResult = topics.ProjectTo<TopicViewModel>().ToList();

            //Act & Assert
            topicsController.WithCallTo(c => c.Index()).ShouldRenderView("Index")
                .WithModel<IList<TopicViewModel>>(x =>
                {
                    Assert.AreEqual(x.FirstOrDefault().Id, expectedResult.FirstOrDefault().Id);
                    Assert.AreEqual(x.FirstOrDefault().Name, expectedResult.FirstOrDefault().Name);
                    Assert.AreEqual(x.FirstOrDefault().Description, expectedResult.FirstOrDefault().Description);
                });
        }
    }
}

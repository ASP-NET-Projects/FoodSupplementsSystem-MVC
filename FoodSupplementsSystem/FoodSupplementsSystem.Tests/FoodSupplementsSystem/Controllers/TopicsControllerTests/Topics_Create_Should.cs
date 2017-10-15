﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;
using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Topics;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.TopicsControllerTests
{
    [TestFixture]
    public class Topics_Create_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Topic, TopicViewModel>();
                cfg.CreateMap<TopicViewModel, Topic>();
            });
        }

        [Test]
        public void ReturnJsonResult_WhenGetToTopics_Create()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var topicViewModel = DataHelper.GetAdminTopicViewModel();
            var kendoDataRequest = new DataSourceRequest();

            topicsService.Setup(x => x.Create(It.IsAny<Topic>())).Verifiable();

            var controller = new TopicsController(topicsService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Topics_Create(kendoDataRequest, topicViewModel)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToTopics_Create()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var topicViewModel = DataHelper.GetAdminTopicViewModel();
            var kendoDataRequest = new DataSourceRequest();

            topicsService.Setup(x => x.Create(It.IsAny<Topic>())).Verifiable();

            var controller = new TopicsController(topicsService.Object);

            //Act
            var controllerResult = controller.Topics_Create(kendoDataRequest, topicViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<TopicViewModel>;

            //Assert
            Assert.IsInstanceOf<IEnumerable<TopicViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToTopics_Create()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var topicViewModel = DataHelper.GetAdminTopicViewModel();
            var kendoDataRequest = new DataSourceRequest();

            topicsService.Setup(x => x.Create(It.IsAny<Topic>())).Verifiable();

            var controller = new TopicsController(topicsService.Object);

            //Act
            var controllerResult = controller.Topics_Create(kendoDataRequest, topicViewModel);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<TopicViewModel>;

            //Assert
            Assert.AreEqual(topicViewModel, results.FirstOrDefault());
            Assert.AreEqual(topicViewModel.Id, results.FirstOrDefault().Id);
            Assert.AreEqual(topicViewModel.Name, results.FirstOrDefault().Name);
            Assert.AreEqual(topicViewModel.Description, results.FirstOrDefault().Description);
        }
    }
}

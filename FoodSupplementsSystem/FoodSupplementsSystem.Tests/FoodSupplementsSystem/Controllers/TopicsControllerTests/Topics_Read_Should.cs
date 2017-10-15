using System.Collections.Generic;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;
using Kendo.Mvc.UI;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Topics;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.TopicsControllerTests
{
    [TestFixture]
    public class Topics_Read_Should
    {
        [Test]
        public void ReturnJsonResult_WhenGetToTopics_Read()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var topics = DataHelper.GetTopics();
            var kendoDataRequest = new DataSourceRequest();

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            var controller = new TopicsController(topicsService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Topics_Read(kendoDataRequest)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToTopics_Read()
        {
            //Arrange
            var topicsService = new Mock<ITopicsService>();
            var topics = DataHelper.GetTopics();
            var kendoDataRequest = new DataSourceRequest();

            topicsService.Setup(x => x.GetAll()).Returns(topics);

            var controller = new TopicsController(topicsService.Object);

            //Act
            var controllerResult = controller.Topics_Read(kendoDataRequest);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<TopicViewModel>;

            //Assert
            Assert.IsInstanceOf<IList<TopicViewModel>>(results);
        }
    }
}

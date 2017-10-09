using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.TopicsServiceTests
{
    [TestFixture]
    public class UpdateById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicName = topic.Name;
            var topicDescription = topic.Description;
            var topicId = 0;
            var topicsService = new TopicsService(topics.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => topicsService.UpdateById(topicId, topicName, topicDescription));
        }

        [Test]
        public void Throw_WhenNameParameterIsInvalid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicDescription = topic.Description;
            var topicId = topic.Id;
            var topicsService = new TopicsService(topics.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => topicsService.UpdateById(topicId, null, topicDescription));
        }

        [Test]
        public void Throw_WhenDescriptionParameterIsInvalid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicName = topic.Name;
            var topicId = topic.Id;
            var topicsService = new TopicsService(topics.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => topicsService.UpdateById(topicId, topicName, null));
        }

        //TODO: fix service not to make two requestс to the database
        //[Test]
        //public void InvokeRepositoryMethosGetByIdOnce()
        //{
        //    //Arrange
        //    var topics = new Mock<IEfGenericRepository<Topic>>();
        //    var topic = DataHelper.GetTopic();
        //    var topicName = topic.Name;
        //    var topicDescription = topic.Description;
        //    var topicId = topic.Id;
        //    topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(topic);
        //    var topicsService = new TopicsService(topics.Object);
        //
        //    //Act
        //    topicsService.UpdateById(topicId, topicName, topicDescription);
        //
        //    //Assert
        //    topics.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        //}
    }
}

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
    public class GetById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            // Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var invalidTopicId = 0;
            var topicsService = new TopicsService(topics.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => topicsService.GetById(invalidTopicId));
        }

        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicId = topic.Id;
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(topic);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetById(topicId);

            //Assert
            Assert.IsInstanceOf<Topic>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicId = topic.Id;
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(topic);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetById(topicId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, topic);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicId = topic.Id;
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(topic);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetById(topicId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, topic);
            Assert.AreEqual(result.Id, topic.Id);
            Assert.AreEqual(result.Name, topic.Name);
            Assert.AreEqual(result.Description, topic.Description);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodGetById_ReturnsNull()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicId = topic.Id;
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetById(topicId);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosGetByIdOnce()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicId = topic.Id;
            topics.Setup(x => x.GetById(It.IsAny<int>())).Returns(topic);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetById(topicId);

            //Assert
            topics.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}

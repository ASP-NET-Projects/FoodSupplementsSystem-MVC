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
    public class Create_Should
    {
        [Test]
        public void Throw_WhenPassedParametersAreNull()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsService = new TopicsService(topics.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => topicsService.Create(null, null));
        }

        [Test]
        public void ReturnCorrectInstance_WhenPassedParametersAreValid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicName = topic.Name;
            var topicCategory = topic.Description;
            topics.Setup(x => x.Add(It.IsAny<Topic>())).Verifiable();
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.Create(topicName, topicCategory);

            //Assert
            Assert.IsInstanceOf<Topic>(result);
        }

        [Test]
        public void ReturnCorrectModel_WhenPassedParametersAreValid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicName = topic.Name;
            var topicCategory = topic.Description;
            topics.Setup(x => x.Add(It.IsAny<Topic>())).Verifiable();
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.Create(topicName, topicCategory);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(topic.Name, result.Name);
            Assert.AreEqual(topic.Description, result.Description);
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenPassedParametersAreValid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicName = topic.Name;
            var topicCategory = topic.Description;
            topics.Setup(x => x.Add(It.IsAny<Topic>())).Verifiable();
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.Create(topicName, topicCategory);

            //Assert
            topics.Verify(x => x.Add(It.IsAny<Topic>()), Times.Once);
        }
    }
}

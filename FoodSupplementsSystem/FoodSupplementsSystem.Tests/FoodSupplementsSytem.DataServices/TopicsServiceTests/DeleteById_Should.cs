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
    public class DeleteById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var invalidTopicId = 0;
            var topicsService = new TopicsService(topics.Object);


            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => topicsService.DeleteById(invalidTopicId));
        }

        [Test]
        public void InvokeRepositoryMethosDeleteOnce()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            var topicId = topic.Id;
            topics.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();
            var topicsService = new TopicsService(topics.Object);

            //Act
            topicsService.DeleteById(topicId);

            //Assert
            topics.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}

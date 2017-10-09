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
    public class Delete_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsNull()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsService = new TopicsService(topics.Object);


            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => topicsService.Delete(null));
        }

        [Test]
        public void InvokeRepositoryMethosDeleteOnce()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            topics.Setup(x => x.Delete(It.IsAny<Topic>())).Verifiable();
            var topicsService = new TopicsService(topics.Object);

            //Act
            topicsService.Delete(topic);

            //Assert
            topics.Verify(x => x.Delete(It.IsAny<Topic>()), Times.Once);
        }
    }
}

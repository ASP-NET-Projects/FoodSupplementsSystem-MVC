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
    public class Update_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsNull()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsService = new TopicsService(topics.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => topicsService.Update(null));
        }

        [Test]
        public void InvokeRepositoryMethosUpdateOnce()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            topics.Setup(x => x.Update(It.IsAny<Topic>())).Verifiable();
            var topicsService = new TopicsService(topics.Object);

            //Act
            topicsService.Update(topic);

            //Assert
            topics.Verify(x => x.Update(It.IsAny<Topic>()), Times.Once);
        }
    }
}

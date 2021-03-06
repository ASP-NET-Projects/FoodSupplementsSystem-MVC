﻿using System;

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
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsService = new TopicsService(topics.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => topicsService.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topic = DataHelper.GetTopic();
            topics.Setup(x => x.Add(It.IsAny<Topic>())).Verifiable();
            var topicsService = new TopicsService(topics.Object);

            //Act
            topicsService.Create(topic);

            //Assert
            topics.Verify(x => x.Add(It.IsAny<Topic>()), Times.Once);
        }
    }
}

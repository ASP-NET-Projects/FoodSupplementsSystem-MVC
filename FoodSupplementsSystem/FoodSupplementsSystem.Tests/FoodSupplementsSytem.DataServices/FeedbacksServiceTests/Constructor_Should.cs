using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.FeedbacksServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstance_WhenParameterIsNotNull()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act & Assert
            Assert.IsInstanceOf<IFeedbacksService>(feedbacksService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FeedbacksService(null));
        }
    }
}

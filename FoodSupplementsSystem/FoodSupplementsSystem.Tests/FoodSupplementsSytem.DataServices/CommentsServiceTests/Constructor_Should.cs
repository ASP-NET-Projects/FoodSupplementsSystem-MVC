using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CommentsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstance_WhenParameterIsNotNull()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            var commentsService = new CommentsService(comments.Object);

            //Act & Assert
            Assert.IsInstanceOf<ICommentsService>(commentsService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommentsService(null));
        }
    }
}

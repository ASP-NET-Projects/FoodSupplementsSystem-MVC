using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Infrastructure.Services.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Infrastucture.Services.HomeServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstance_WhenParametersAreNotNull()
        {
            //Arrange
            var brands = new Mock<IBrandsService>();
            var topics = new Mock<ITopicsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act & Assert
            Assert.IsInstanceOf<IHomeService>(homeService);
        }

        [Test]
        public void Throw_WhenNullParametersArePassed()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeService(null, null, null, null));
        }
    }
}

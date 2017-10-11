using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Infrastructure.Caching;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Infrastucture.Populators.DropDownListPopulatorTests
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
            var cache = new Mock<ICacheService>();
            var dropDownListPopulator = new DropDownListPopulator(categories.Object, brands.Object, topics.Object, cache.Object);

            //Act & Assert
            Assert.IsInstanceOf<IDropDownListPopulator>(dropDownListPopulator);
        }

        [Test]
        public void Throw_WhenNullParametersArePassed()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DropDownListPopulator(null, null, null, null));
        }
    }
}

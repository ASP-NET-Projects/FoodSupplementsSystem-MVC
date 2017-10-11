using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Infrastructure.Caching;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Infrastucture.Populators.DropDownListPopulatorTests
{
    [TestFixture]
    public class GetTopics_Should
    {
        [Test]
        public void ReturnCorrectModelInstance()
        {
            //Arrange
            var brands = new Mock<IBrandsService>();
            var topics = new Mock<ITopicsService>();
            var categories = new Mock<ICategoriesService>();
            var cache = new Mock<ICacheService>();
            var topicsCollection = DataHelper.GetTopicsSelectedCollection();
            topics.Setup(x => x.GetAll()).Returns(topicsCollection);
            var dropDownListPopulator = new DropDownListPopulator(categories.Object, brands.Object, topics.Object, cache.Object);

            //Act
            var result = dropDownListPopulator.GetTopics();

            //Assert
            Assert.IsInstanceOf<IEnumerable<SelectListItem>>(result);
        }

        [Test]
        public void ReturnsCorrectModel()
        {
            //Arrange
            var brands = new Mock<IBrandsService>();
            var topics = new Mock<ITopicsService>();
            var categories = new Mock<ICategoriesService>();
            var cache = new Mock<ICacheService>();
            var topicsCollection = DataHelper.GetSessionTopics();
            //cache.Setup(x => x.Get("topics", () => topicsCollection));
            cache.SetReturnsDefault(topicsCollection);
            var dropDownListPopulator = new DropDownListPopulator(categories.Object, brands.Object, topics.Object, cache.Object);

            //Act
            var result = dropDownListPopulator.GetCategories();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(topicsCollection, result);
            Assert.AreEqual(topicsCollection.FirstOrDefault().Value, result.FirstOrDefault().Value);
            Assert.AreEqual(topicsCollection.FirstOrDefault().Text, result.FirstOrDefault().Text);
        }
    }
}

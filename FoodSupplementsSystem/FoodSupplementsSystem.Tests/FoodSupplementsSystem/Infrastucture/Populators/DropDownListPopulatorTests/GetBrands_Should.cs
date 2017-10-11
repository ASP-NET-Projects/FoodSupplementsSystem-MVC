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
    public class GetBrands_Should
    {
        [Test]
        public void ReturnCorrectModelInstance()
        {
            //Arrange
            var brands = new Mock<IBrandsService>();
            var topics = new Mock<ITopicsService>();
            var categories = new Mock<ICategoriesService>();
            var cache = new Mock<ICacheService>();
            var brandsCollection = DataHelper.GetBrandsSelectedCollection();
            brands.Setup(x => x.GetAll()).Returns(brandsCollection);
            var dropDownListPopulator = new DropDownListPopulator(categories.Object, brands.Object, topics.Object, cache.Object);

            //Act
            var result = dropDownListPopulator.GetBrands();

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
            var brandsCollection = DataHelper.GetSessionBrands();
            //cache.Setup(x => x.Get("brands", () => brandsCollection));
            cache.SetReturnsDefault(brandsCollection);
            var dropDownListPopulator = new DropDownListPopulator(categories.Object, brands.Object, topics.Object, cache.Object);

            //Act
            var result = dropDownListPopulator.GetCategories();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(brandsCollection, result);
            Assert.AreEqual(brandsCollection.FirstOrDefault().Value, result.FirstOrDefault().Value);
            Assert.AreEqual(brandsCollection.FirstOrDefault().Text, result.FirstOrDefault().Text);
        }
    }
}

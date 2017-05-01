using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.BrandsServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            BrandsService brandsService = new BrandsService(brandsMock.Object);

            //Act
            IQueryable<Brand> brandResult = brandsService.GetAll();

            //Assert
            brandsMock.Verify(c => c.All(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            IQueryable<Brand> expectedResultCollection = new List<Brand>().AsQueryable();

            brandsMock.Setup(c => c.All()).Returns(() =>
            {
                return expectedResultCollection;
            });

            BrandsService brandsService = new BrandsService(brandsMock.Object);

            //Act
            IQueryable<Brand> brandResult = brandsService.GetAll();

            //Assert
            Assert.That(brandResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();

            brandsMock.Setup(c => c.All()).Returns(() =>
            {
                IQueryable<Brand> expectedResultCollection = new List<Brand>().AsQueryable();
                return expectedResultCollection;
            });

            BrandsService brandsService = new BrandsService(brandsMock.Object);

            //Act
            IQueryable<Brand> brandResult = brandsService.GetAll();

            //Assert
            Assert.That(brandResult, Is.InstanceOf<IQueryable<Brand>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();

            brandsMock.Setup(c => c.All()).Returns(() =>
            {
                return null;
            });

            BrandsService brandsService = new BrandsService(brandsMock.Object);

            //Act
            IQueryable<Brand> brandResult = brandsService.GetAll();

            //Assert
            Assert.IsNull(brandResult);
        }
    }
}

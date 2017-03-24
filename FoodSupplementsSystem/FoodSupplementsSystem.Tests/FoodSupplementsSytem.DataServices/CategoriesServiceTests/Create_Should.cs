using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using Moq;
using NUnit.Framework;
using System;
namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_WhenThePassedCategoryIsNull()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenThePassedCategoryIsValid()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);
            int categoryId = 6;
            Category category = new Category() { Id = categoryId, Name = "Amino Acids" };

            //Act
            categoriesService.Create(category.Name);

            //Assert
            categoriesMock.Verify(x => x.Add(It.IsAny<Category>()), Times.Once);
        }
    }
}

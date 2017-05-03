using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsInvalid()
        {
            // Arrange
            var categoriesMock = new Mock<IEfGenericRepository<Category>>();
            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);

            // Act
            Category categoryResult = categoriesService.GetById(-1);

            // Assert
            Assert.IsNull(categoryResult);
        }

        [Test]
        public void ReturnCategory_WhenIdIsValid()
        {
            //Arrange
            var categoriesMock = new Mock<IEfGenericRepository<Category>>();
            int categoryId = 1;
            Category category = new Category() { Id = categoryId, Name = "Category1" };

            categoriesMock.Setup(c => c.GetById(categoryId)).Returns(category);

            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);

            //Act
            Category categoryResult = categoriesService.GetById(categoryId);

            //Assert
            Assert.AreSame(category, categoryResult);
        }
    }
}

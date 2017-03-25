using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class DeleteById_Should
    {
       //[Test]
       //public void Throw_WhenThePassedCategoryIsNull()
       //{
       //    //Arrange
       //    var categoriesMock = new Mock<IRepository<Category>>();
       //    CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);
       //
       //    //Act & Assert
       //    Assert.Throws<InvalidOperationException>(() => categoriesService.DeleteById(-1));
       //}
       //
       //[Test]
       //public void InvokeRepositoryMethodDeleteOnce_WhenThePassedCategoryIsValid()
       //{
       //    //Arrange
       //    var categoriesMock = new Mock<IRepository<Category>>();
       //    Category fakeCategory = new Category();
       //    CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);
       //    categoriesMock.Setup(x => x.Delete(fakeCategory)).Verifiable();
       //
       //    //Act
       //    categoriesService.DeleteById(fakeCategory.Id);
       //
       //    //Assert
       //    categoriesMock.Verify(x => x.Delete(fakeCategory), Times.Once);
       //}
    }
}

using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllCategories;
using AutoMapper.QueryableExtensions;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllCategoriesControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void RunDefaultView_WhenGetToIndex()
        {
            // Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var categories = GetCategories();

            categoriesServiceMock.Setup(x => x.GetAll())
                .Returns(categories);

            AutoMapperConfig.Config();

            var controller = new AllCategoriesController(categoriesServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnCorrectModelType_WhenGetToIndex()
        {
            //Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var categories = GetCategories();

            categoriesServiceMock.Setup(s => s.GetAll()).Returns(categories);

            AutoMapperConfig.Config();

            var categoriesController = new AllCategoriesController(categoriesServiceMock.Object);

            //Act & Assert
            categoriesController.WithCallTo(c => c.Index()).ShouldRenderView("Index").WithModel<List<CategoryViewModel>>();
        }

        [Test]
        public void ReturnCorrectResultModel_WhenGetToIndex()
        {
            //Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var categories = GetCategories();

            categoriesServiceMock.Setup(s => s.GetAll()).Returns(categories);

            AutoMapperConfig.Config();

            var categoriesController = new AllCategoriesController(categoriesServiceMock.Object);
            var expectedResult = categories.ProjectTo<CategoryViewModel>().ToList();

            //Act & Assert
            categoriesController.WithCallTo(c => c.Index()).ShouldRenderView("Index")
                .WithModel<IList<CategoryViewModel>>(x =>
                {
                    Assert.AreEqual(x.FirstOrDefault().Id, expectedResult.FirstOrDefault().Id);
                    Assert.AreEqual(x.FirstOrDefault().Name, expectedResult.FirstOrDefault().Name);
                });
        }

        private IQueryable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new Category()
                {
                    Id = i,
                    Name = "category" + i
                });
            }

            return categories.AsQueryable();
        }
    }
}

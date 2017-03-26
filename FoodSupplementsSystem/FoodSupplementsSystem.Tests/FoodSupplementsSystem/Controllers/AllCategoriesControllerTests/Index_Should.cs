using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

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
                .Returns(categories.AsQueryable());

            AutoMapperConfig.Config();

            var controller = new AllCategoriesController(categoriesServiceMock.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        private IEnumerable<Category> GetCategories()
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

            return categories;
        }
    }
}

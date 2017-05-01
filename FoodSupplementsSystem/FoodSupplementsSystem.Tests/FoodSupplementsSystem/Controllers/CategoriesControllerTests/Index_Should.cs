using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.CategoriesControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView_WhenGetToIndex()
        {
            // Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var categoriesController = new CategoriesController(categoriesServiceMock.Object);

            // Act && Assert
            categoriesController.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }
    }
}

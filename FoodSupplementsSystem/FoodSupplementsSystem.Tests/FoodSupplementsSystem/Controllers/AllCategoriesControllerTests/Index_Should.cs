using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllCategories;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllCategoriesControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<Supplement, SupplementViewModel>();
                cfg.CreateMap<SupplementViewModel, Supplement>();
            });
        }

        [Test]
        public void RunDefaultView_WhenGetToIndex()
        {
            // Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var categories = DataHelper.GetCategories();

            categoriesServiceMock.Setup(x => x.GetAll())
                .Returns(categories);

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
            var categories = DataHelper.GetCategories();

            categoriesServiceMock.Setup(s => s.GetAll()).Returns(categories);

            var categoriesController = new AllCategoriesController(categoriesServiceMock.Object);

            //Act & Assert
            categoriesController.WithCallTo(c => c.Index()).ShouldRenderView("Index").WithModel<List<CategoryViewModel>>();
        }

        [Test]
        public void ReturnCorrectResultModel_WhenGetToIndex()
        {
            //Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var categories = DataHelper.GetCategories();

            categoriesServiceMock.Setup(s => s.GetAll()).Returns(categories);

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
    }
}

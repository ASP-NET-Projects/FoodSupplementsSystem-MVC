using System.Collections.Generic;
using System.Linq;

using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;

using FoodSupplementsSystem.Infrastructure.Services.Contracts;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.ViewModels.AllCategories;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using FoodSupplementsSystem.ViewModels.Home;

namespace FoodSupplementsSystem.Infrastructure.Services
{
    public class HomeService : IHomeService
    {
        private ITopicsService topics;

        private IBrandsService brands;

        private ICategoriesService categories;

        private ISupplementsService supplements;

        public HomeService(ITopicsService topics, IBrandsService brands, ICategoriesService categories, ISupplementsService supplements)
        {
            Guard.WhenArgument(topics, "topics").IsNull().Throw();
            Guard.WhenArgument(brands, "brands").IsNull().Throw();
            Guard.WhenArgument(categories, "categories").IsNull().Throw();
            Guard.WhenArgument(supplements, "supplements").IsNull().Throw();

            this.supplements = supplements;
            this.categories = categories;
            this.brands = brands;
            this.topics = topics;
        }

        public IList<HomeTopicViewModel> GetTopicViewModel(int numberOfTopics)
        {
            Guard.WhenArgument(numberOfTopics, "numberOfTopics").IsLessThan(0).Throw();

            var topicViewModel = this.topics
                .GetAll()
                .OrderByDescending(t => t.Comments.Count())
                .Take(numberOfTopics)
                .ProjectTo<HomeTopicViewModel>()
                .ToList();

            return topicViewModel;
        }

        public IList<BrandViewModel> GetLastBrands()
        {
            var brands = this.brands
                .GetLast3()
                .ProjectTo<BrandViewModel>()
                .ToList();

            return brands;
        }

        public IList<CategoryViewModel> GetLastCategories()
        {
            var categories = this.categories
                .GetLast3()
                .ProjectTo<CategoryViewModel>()
                .ToList();

            return categories;
        }

        public IList<SupplementViewModel> GetLastSupplements()
        {
            var supplements = this.supplements
                .GetLast3()
                .ProjectTo<SupplementViewModel>()
                .ToList();

            return supplements;
        }
    }
}
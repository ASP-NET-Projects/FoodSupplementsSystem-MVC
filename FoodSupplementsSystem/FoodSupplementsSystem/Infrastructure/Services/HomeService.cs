using System.Collections.Generic;
using System.Linq;

using AutoMapper.QueryableExtensions;

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
            this.supplements = supplements;
            this.categories = categories;
            this.brands = brands;
            this.topics = topics;
        }

        public IList<TopicViewModel> GetTopicViewModel(int numberOfTopics)
        {
            var topicViewModel = this.topics
                .GetAll()
                .OrderByDescending(t => t.Comments.Count())
                .Take(numberOfTopics)
                .ProjectTo<TopicViewModel>()
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
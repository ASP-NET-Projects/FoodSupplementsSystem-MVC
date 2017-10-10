using FoodSupplementsSystem.ViewModels.Home;
using System.Collections.Generic;
using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.ViewModels.AllCategories;
using FoodSupplementsSystem.ViewModels.AllSupplements;

namespace FoodSupplementsSystem.Infrastructure.Services
{
    public interface IHomeService
    {
        IList<TopicViewModel> GetTopicViewModel(int numberOfTopics);

        IList<BrandViewModel> GetLastBrands();

        IList<CategoryViewModel> GetLastCategories();

        IList<SupplementViewModel> GetLastSupplements();
    }
}

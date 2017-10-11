using System.Collections.Generic;

using FoodSupplementsSystem.ViewModels.AllBrands;
using FoodSupplementsSystem.ViewModels.AllCategories;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using FoodSupplementsSystem.ViewModels.Home;

namespace FoodSupplementsSystem.Infrastructure.Services.Contracts
{
    public interface IHomeService
    {
        IList<HomeTopicViewModel> GetTopicViewModel(int numberOfTopics);

        IList<BrandViewModel> GetLastBrands();

        IList<CategoryViewModel> GetLastCategories();

        IList<SupplementViewModel> GetLastSupplements();
    }
}

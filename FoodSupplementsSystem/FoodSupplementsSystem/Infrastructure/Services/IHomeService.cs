using FoodSupplementsSystem.ViewModels.Home;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Infrastructure.Services
{
    public interface IHomeService
    {
        IList<TopicViewModel> GetTopicViewModel(int numberOfTopics);
    }
}

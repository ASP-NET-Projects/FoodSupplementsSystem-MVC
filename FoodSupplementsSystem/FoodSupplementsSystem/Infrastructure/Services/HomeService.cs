using AutoMapper.QueryableExtensions;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.Home;
using System.Collections.Generic;
using System.Linq;

namespace FoodSupplementsSystem.Infrastructure.Services
{
    public class HomeService : IHomeService
    {
        private ITopicsService topics;

        public HomeService(ITopicsService topics)
        {
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
    }
}
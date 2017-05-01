using System.Collections.Generic;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.ViewModels.AllCategories;

namespace FoodSupplementsSystem.ViewModels.AllTopics
{
    public class TopicViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SupplementViewModel> Supplements { get; set; }
    }
}
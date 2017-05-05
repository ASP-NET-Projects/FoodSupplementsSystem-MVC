using System.Collections.Generic;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.ViewModels.AllComments;

namespace FoodSupplementsSystem.ViewModels.AllTopics
{
    public class DetailsTopicViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.ViewModels.AllComments;
using System.Collections.Generic;

namespace FoodSupplementsSystem.ViewModels.AllTopics
{
    public class TopicDetailsViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
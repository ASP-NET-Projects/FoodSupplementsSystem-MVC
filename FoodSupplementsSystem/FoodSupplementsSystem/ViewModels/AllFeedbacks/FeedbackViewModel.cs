using FoodSupplementsSystem.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.ViewModels.AllFeedbacks
{
    public class FeedbackViewModel : IMapFrom<Feedback>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
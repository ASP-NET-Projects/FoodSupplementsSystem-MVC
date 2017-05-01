using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;

namespace FoodSupplementsSystem.ViewModels.AllFeedbacks
{
    public class FeedbackViewModel : IMapFrom<Feedback>
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
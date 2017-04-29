using FoodSupplementsSystem.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;
using FoodSupplementsSystem.Data.Models;
using System.Web.Mvc;

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
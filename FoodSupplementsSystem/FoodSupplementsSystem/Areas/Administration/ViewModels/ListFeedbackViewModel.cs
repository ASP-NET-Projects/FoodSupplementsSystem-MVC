using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Areas.Administration.ViewModels
{
    public class ListFeedbackViewModel : IMapFrom<Feedback>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<FeedbackViewModel> Feedbacks { get; set; }
    }
}
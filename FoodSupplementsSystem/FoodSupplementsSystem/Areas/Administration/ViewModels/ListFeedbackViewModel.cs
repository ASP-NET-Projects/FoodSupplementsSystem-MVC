using System.Collections.Generic;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;

namespace FoodSupplementsSystem.Areas.Administration.ViewModels
{
    public class ListFeedbackViewModel : IMapFrom<Feedback>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<FeedbackViewModel> Feedbacks { get; set; }
    }
}
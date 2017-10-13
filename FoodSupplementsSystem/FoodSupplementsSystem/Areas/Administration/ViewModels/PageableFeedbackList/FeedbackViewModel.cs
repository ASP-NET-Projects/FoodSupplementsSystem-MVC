using System;

using AutoMapper;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.Infrastructure.Sanitizer;

namespace FoodSupplementsSystem.Areas.Administration.ViewModels.PageableFeedbackList
{
    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        private readonly ISanitizer sanitizer;

        public FeedbackViewModel()
        {
            sanitizer = new HtmlSanitizerAdapter();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public DateTime CreationDate { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(s => s.AuthorName, opt => opt.MapFrom(s => s.Author.UserName));
        }
    }
}
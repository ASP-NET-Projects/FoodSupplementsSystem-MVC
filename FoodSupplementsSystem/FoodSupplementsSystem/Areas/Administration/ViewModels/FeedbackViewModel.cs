using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using System;
using AutoMapper;

namespace FoodSupplementsSystem.Areas.Administration.ViewModels
{
    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(s => s.AuthorName, opt => opt.MapFrom(s => s.Author.UserName));
        }
    }
}
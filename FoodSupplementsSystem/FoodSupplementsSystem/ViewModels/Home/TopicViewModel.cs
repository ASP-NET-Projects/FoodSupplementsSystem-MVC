using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using System.Linq;
using AutoMapper;

namespace FoodSupplementsSystem.ViewModels.Home
{
    public class TopicViewModel : IMapFrom<Topic>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfComments { get; set; }

        public int NumberOfSupplements { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Topic, TopicViewModel>()
                .ForMember(m => m.NumberOfComments, opt => opt.MapFrom(t => t.Comments.Count()))
                .ForMember(m => m.NumberOfSupplements, opt => opt.MapFrom(t => t.Supplements.Count()))
                .ReverseMap();
        }
    }
}
using System.Linq;

using AutoMapper;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;

namespace FoodSupplementsSystem.ViewModels.Home
{
    public class HomeTopicViewModel : IMapFrom<Topic>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfComments { get; set; }

        public int NumberOfSupplements { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Topic, HomeTopicViewModel>()
                .ForMember(m => m.NumberOfComments, opt => opt.MapFrom(t => t.Comments.Count()))
                .ForMember(m => m.NumberOfSupplements, opt => opt.MapFrom(t => t.Supplements.Count()))
                .ReverseMap();
        }
    }
}
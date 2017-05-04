using AutoMapper;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;

namespace FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements
{
    public class SupplementViewModel : IMapFrom<Supplement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Ingredients { get; set; }

        public string Use { get; set; }

        public string Description { get; set; }

        public string DateCreated { get; set; }

        public string AuthorName { get; set; }

        public string SupplementCategory { get; set; }

        public string SupplementTopic { get; set; }

        public string SupplementBrand { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Supplement, SupplementViewModel>()
                .ForMember(s => s.AuthorName, opt => opt.MapFrom(s => s.Author.UserName))
                .ForMember(s => s.SupplementCategory, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(s => s.SupplementTopic, opt => opt.MapFrom(s => s.Topic.Name))
                .ForMember(s => s.SupplementBrand, opt => opt.MapFrom(s => s.Brand.Name))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(s => s.CreationDate))
                .ReverseMap();
        }
    }
}
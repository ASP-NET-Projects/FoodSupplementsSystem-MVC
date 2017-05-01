using AutoMapper;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;

namespace FoodSupplementsSystem.ViewModels.AllSupplements
{
    public class DetailsSupplementViewModel : IMapFrom<Supplement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Ingredients { get; set; }

        public string Use { get; set; }

        public string Description { get; set; }

        public string DateCreated { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public string TopicName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Supplement, DetailsSupplementViewModel>()
                .ForMember(m => m.DateCreated, opt => opt.MapFrom(s => s.CreationDate))
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(s => s.Author.UserName))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(m => m.BrandName, opt => opt.MapFrom(s => s.Brand.Name))
                .ForMember(m => m.TopicName, opt => opt.MapFrom(s => s.Topic.Name))
                .ReverseMap();
        }
    }
}
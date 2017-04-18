using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using AutoMapper;

namespace FoodSupplementsSystem.ViewModels.AllSupplements
{
    public class ListSupplementViewModel : IMapFrom<Supplement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        //public string Image { get; set; }

        public string SupplementName { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public string TopicName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Supplement, ListSupplementViewModel>()
                //.ForMember(m => m.Image, opt => opt.MapFrom(s => s.ImageUrl))
                .ForMember(m => m.SupplementName, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(s => s.Category))
                .ForMember(m => m.BrandName, opt => opt.MapFrom(s => s.Brand))
                .ForMember(m => m.TopicName, opt => opt.MapFrom(s => s.Topic))
                .ReverseMap();
        }
    }
}
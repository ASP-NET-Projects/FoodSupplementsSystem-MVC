using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using AutoMapper;

namespace FoodSupplementsSystem.ViewModels.AllComments
{
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string DateCreated { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                .ForMember(c => c.DateCreated, opt => opt.MapFrom(c => c.CreationDate))
                .ReverseMap();
        }
    }
}
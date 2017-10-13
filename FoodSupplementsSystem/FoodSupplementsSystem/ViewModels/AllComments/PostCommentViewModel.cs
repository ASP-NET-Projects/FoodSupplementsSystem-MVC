using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;

namespace FoodSupplementsSystem.ViewModels.AllComments
{
    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {

        }

        public PostCommentViewModel(int topicId) 
        {
            this.TopicId = topicId;
        }

        public int TopicId { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}
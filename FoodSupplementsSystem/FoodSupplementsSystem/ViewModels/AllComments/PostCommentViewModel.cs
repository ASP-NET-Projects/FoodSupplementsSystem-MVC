﻿using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;

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
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}
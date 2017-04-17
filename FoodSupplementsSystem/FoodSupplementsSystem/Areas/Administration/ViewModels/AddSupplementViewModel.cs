using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Areas.Administration.ViewModels
{
    public class AddSupplementViewModel : IMapFrom<Supplement>
    {
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        [UIHint("SingleLineText")]
        public string Name { get; set; }

        [Required]
        [UIHint("SingleLineText")]
        public string ImageUrl { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        public string Ingredients { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        public string Use { get; set; }

        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Topic")]
        [UIHint("DropDownList")]
        public int TopicId { get; set; }

        public IEnumerable<SelectListItem> Topics { get; set; }

        [Display(Name = "Brand")]
        [UIHint("DropDownList")]
        public int BrandId { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }
    }
}
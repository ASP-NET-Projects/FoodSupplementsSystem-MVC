using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.Infrastructure.Validation;

namespace FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements
{
    public class AddSupplementViewModel : IMapFrom<Supplement>
    {
        [DoesNotContain("name")]
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        [UIHint("SingleLineText")]
        public string Name { get; set; }

        [DoesNotContain("imageUrl")]
        [Required]
        [UIHint("SingleLineText")]
        public string ImageUrl { get; set; }

        [DoesNotContain("ingredients")]
        [Required]
        [UIHint("MultiLineText")]
        public string Ingredients { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        public string Use { get; set; }

        [DoesNotContain("description")]
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
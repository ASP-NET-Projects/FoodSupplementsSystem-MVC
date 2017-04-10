using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Models.AllCategories
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SupplementViewModel> Supplements { get; set; }
    }
}
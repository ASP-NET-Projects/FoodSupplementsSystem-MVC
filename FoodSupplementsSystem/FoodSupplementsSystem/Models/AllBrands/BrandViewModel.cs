using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.Models.AllCategories;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Models.AllBrands
{
    public class BrandViewModel : IMapFrom<Brand>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebSite { get; set; }

        public ICollection<SupplementViewModel> Supplements { get; set; }
    }
}
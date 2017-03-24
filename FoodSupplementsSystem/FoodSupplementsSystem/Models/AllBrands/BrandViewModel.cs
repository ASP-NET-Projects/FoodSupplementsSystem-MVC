using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodSupplementsSystem.Models.AllBrands
{
    public class BrandViewModel : IMapFrom<Brand>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebSite { get; set; }
    }
}
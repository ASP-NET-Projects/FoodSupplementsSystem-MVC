﻿using System.Collections.Generic;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;
using FoodSupplementsSystem.ViewModels.AllSupplements;

namespace FoodSupplementsSystem.ViewModels.AllCategories
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SupplementViewModel> Supplements { get; set; }
    }
}
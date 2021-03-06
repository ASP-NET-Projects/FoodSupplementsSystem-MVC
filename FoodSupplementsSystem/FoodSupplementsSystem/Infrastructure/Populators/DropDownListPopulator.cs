﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using FoodSupplementsSystem.Infrastructure.Caching;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Infrastructure.Populators
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private readonly ICategoriesService categories;
        private readonly IBrandsService brands;
        private readonly ITopicsService topics;
        private readonly ICacheService cache;

        public DropDownListPopulator(ICategoriesService categories, IBrandsService brands, ITopicsService topics, ICacheService cache)
        {
            Guard.WhenArgument(topics, "topics").IsNull().Throw();
            Guard.WhenArgument(brands, "brands").IsNull().Throw();
            Guard.WhenArgument(categories, "categories").IsNull().Throw();
            Guard.WhenArgument(cache, "cache").IsNull().Throw();

            this.categories = categories;
            this.brands = brands;
            this.topics = topics;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.cache.Get<IEnumerable<SelectListItem>>("categories",
                () =>
                {
                    return this.categories
                    .GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToList();
                });

            return categories;
        }

        public IEnumerable<SelectListItem> GetTopics()
        {
            var topics = this.cache.Get<IEnumerable<SelectListItem>>("topics",
                () =>
                {
                    return this.topics
                    .GetAll()
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.Name
                    })
                    .ToList();
                });

            return topics;
        }

        public IEnumerable<SelectListItem> GetBrands()
        {
            var brands = this.cache.Get<IEnumerable<SelectListItem>>("brands",
                () =>
                {
                    return this.brands
                    .GetAll()
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Name
                    })
                    .ToList();
                });

            return brands;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using FoodSupplementsSystem.Infrastructure.Caching;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Infrastructure.Populators
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private ICategoriesService categories;
        private IBrandsService brands;
        private ITopicsService topics;
        private ICacheService cache;

        public DropDownListPopulator(ICategoriesService categories, IBrandsService brands, ITopicsService topics, ICacheService cache)
        {
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
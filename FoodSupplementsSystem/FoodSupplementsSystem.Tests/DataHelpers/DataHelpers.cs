using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Categories;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;

namespace FoodSupplementsSystem.Tests.DataHelpers
{
    internal static class DataHelper
    {
        internal static IQueryable<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();

            for (int i = 1; i <= 10; i++)
            {
                brands.Add(new Brand()
                {
                    Id = i,
                    Name = "brand" + i,
                    WebSite = "website" + i
                });
            }

            return brands.AsQueryable();
        }

        internal static IQueryable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new Category()
                {
                    Id = i,
                    Name = "category" + i
                });
            }

            return categories.AsQueryable();
        }

        internal static IQueryable<Topic> GetTopics()
        {
            List<Topic> topics = new List<Topic>();

            for (int i = 1; i <= 10; i++)
            {
                topics.Add(new Topic()
                {
                    Id = i,
                    Name = "topic" + i,
                    Description = "description" + i
                });
            }

            return topics.AsQueryable();
        }

        internal static IQueryable<Supplement> GetSupplements()
        {
            List<Supplement> supplements = new List<Supplement>();

            for (int i = 1; i <= 10; i++)
            {
                supplements.Add(new Supplement()
                {
                    Id = i,
                    Name = "supplement" + i,
                    ImageUrl = "imageUrl" + i
                });
            }

            return supplements.AsQueryable();
        }

        internal static IQueryable<Supplement> Test()
        {
            List<Supplement> supplements = new List<Supplement>();

            for (int i = 1; i <= 10; i++)
            {
                supplements.Add(new Supplement()
                {
                    Id = i,
                    Name = "supplement" + i,
                    ImageUrl = "imageUrl" + i,
                    Ingredients = "ingredients" + i,
                    Use = "use" + i,
                    Description = "description" + i
                });
            }

            return supplements.AsQueryable();
        }

        internal static IQueryable<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();

            for (int i = 1; i <= 10; i++)
            {
                comments.Add(new Comment()
                {
                    Id = i,
                    Content = "comment" + i + "content",
                    CreationDate = DateTime.Now.AddHours(i)
                });
            }

            return comments.AsQueryable();
        }

        internal static IQueryable<Topic> GetTopicWithComments()
        {
            List<Topic> topicWithComments = new List<Topic>();

            for (int i = 1; i <= 10; i++)
            {
                topicWithComments.Add(new Topic()
                {
                    Id = i,
                    Name = "topic" + i,
                    Description = "description" + i,
                    Comments = GetComments().ToList()
                });
            }

            return topicWithComments.AsQueryable();
        }

        internal static IEnumerable<SelectListItem> GetSelectListItemCollection()
        {
            var collection = new List<SelectListItem>();

            for (int i = 1; i <= 10; i++)
            {
                collection.Add(new SelectListItem()
                {
                    Value = i.ToString(),
                    Text = "text" + i
                });
            }

            return collection;
        }

        internal static IQueryable<Category> GetCategoriesSelectedCollection()
        {
            var collection = new List<Category>();

            for (int i = 1; i <= 10; i++)
            {
                collection.Add(new Category()
                {
                    Id = i,
                    Name = "text" + i
                });
            }

            return collection.AsQueryable();
        }

        internal static IQueryable<Brand> GetBrandsSelectedCollection()
        {
            var collection = new List<Brand>();

            for (int i = 1; i <= 10; i++)
            {
                collection.Add(new Brand()
                {
                    Id = i,
                    Name = "text" + i
                });
            }

            return collection.AsQueryable();
        }

        internal static IQueryable<Topic> GetTopicsSelectedCollection()
        {
            var collection = new List<Topic>();

            for (int i = 1; i <= 10; i++)
            {
                collection.Add(new Topic()
                {
                    Id = i,
                    Name = "text" + i
                });
            }

            return collection.AsQueryable();
        }

        internal static CategoryViewModel GetAdminCategoryViewModel()
        {
            return new CategoryViewModel()
            {
                Id = 1,
                Name = "category name"
            };
        }

        internal static BrandViewModel GetAdminBrandViewModel()
        {
            return new BrandViewModel()
            {
                Id = 1,
                Name = "brans name",
                WebSite = "website name"
            };
        }
    }
}

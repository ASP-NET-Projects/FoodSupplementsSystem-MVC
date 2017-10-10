using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Categories;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Brands;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Topics;
using FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements;

namespace FoodSupplementsSystem.Tests.DataHelpers
{
    internal static class DataHelper
    {
        internal static IQueryable<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();

            for (int i = 1; i <= 10; i++)
            {
                brands.Add(new Brand
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
                categories.Add(new Category
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
                topics.Add(new Topic
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
                supplements.Add(new Supplement
                {
                    Id = i,
                    Name = "supplement" + i,
                    ImageUrl = "imageUrl" + i
                });
            }

            return supplements.AsQueryable();
        }

        internal static IQueryable<Feedback> GetFeedbacks()
        {
            List<Feedback> feedbacks = new List<Feedback>();

            for (int i = 1; i <= 10; i++)
            {
                feedbacks.Add(new Feedback
                {
                    Id = i,
                    Title = "feedback title" + i,
                    Content = "feedback content" + i,
                    CreationDate = DateTime.Now.AddHours(i)
                });
            }

            return feedbacks.AsQueryable();
        }

        internal static IQueryable<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();

            for (int i = 1; i <= 10; i++)
            {
                comments.Add(new Comment
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
                topicWithComments.Add(new Topic
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
                collection.Add(new SelectListItem
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
                collection.Add(new Category
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
                collection.Add(new Brand
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
                collection.Add(new Topic
                {
                    Id = i,
                    Name = "text" + i
                });
            }

            return collection.AsQueryable();
        }

        internal static CategoryViewModel GetAdminCategoryViewModel()
        {
            return new CategoryViewModel
            {
                Id = 1,
                Name = "category name"
            };
        }

        internal static BrandViewModel GetAdminBrandViewModel()
        {
            return new BrandViewModel
            {
                Id = 1,
                Name = "brans name",
                WebSite = "website name"
            };
        }

        internal static TopicViewModel GetAdminTopicViewModel()
        {
            return new TopicViewModel
            {
                Id = 1,
                Name = "topic name",
                Description = "topic description"
            };
        }

        internal static SupplementViewModel GetAdminSupplementViewModel()
        {
            return new SupplementViewModel
            {
                Id = 1,
                Name = "supplement name",
                ImageUrl = "supplement image url",
                Ingredients = "supplement ingredients",
                Use = "supplement use",
                Description = "supplement description"
            };
        }

        internal static Category GetCategory()
        {
            return new Category
            {
                Id = 1,
                Name = "category name"
            };
        }

        internal static Feedback GetFeedback()
        {
            return new Feedback
            {
                Id = 1,
                Title = "feedback title",
                Content = "feedback content",
                CreationDate = DateTime.Now,
                Author = new ApplicationUser()
            };
        }

        internal static Comment GetComment()
        {
            return new Comment
            {
                Id = 1,
                Content = "comment content",
                CreationDate = DateTime.Now
            };
        }

        internal static Topic GetTopic()
        {
            return new Topic
            {
                Id = 1,
                Name = "topic name",
                Description = "topic description"
            };
        }

        internal static Supplement GetSupplement()
        {
            return new Supplement
            {
                Id = 1,
                Name = "supplement name ",
                ImageUrl = "supplement imageUrl"
            };
        }
    }
}

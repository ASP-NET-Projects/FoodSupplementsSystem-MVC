using System;
using System.Collections.Generic;
using System.Linq;

using FoodSupplementsSystem.Data.Models;

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
    }
}

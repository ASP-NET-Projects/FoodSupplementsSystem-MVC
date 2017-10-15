using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.ViewModels.AllComments;
using FoodSupplementsSystem.ViewModels.AllFeedbacks;
using BrandViewModelAdmin = FoodSupplementsSystem.Areas.Administration.ViewModels.Brands.BrandViewModel;
using BrandViewModel = FoodSupplementsSystem.ViewModels.AllBrands.BrandViewModel;
using SupplementViewModelAdmin = FoodSupplementsSystem.Areas.Administration.ViewModels.Supplements.SupplementViewModel;
using SupplementViewModel = FoodSupplementsSystem.ViewModels.AllSupplements.SupplementViewModel;
using TopicViewModelAdmin = FoodSupplementsSystem.Areas.Administration.ViewModels.Topics.TopicViewModel;
using TopicViewModel = FoodSupplementsSystem.ViewModels.AllTopics.TopicViewModel;
using CategoryViewModelAdmin = FoodSupplementsSystem.Areas.Administration.ViewModels.Categories.CategoryViewModel;
using CategoryViewModel = FoodSupplementsSystem.ViewModels.AllCategories.CategoryViewModel;
using FoodSupplementsSystem.ViewModels.Home;

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
                    ImageUrl = "imageUrl" + i,
                    Author = new ApplicationUser(),
                    Brand = new Brand(),
                    Category = new Category(),
                    Topic = new Topic()
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

        internal static IQueryable<Topic> GetTopicsWithComments()
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

        internal static CategoryViewModelAdmin GetAdminCategoryViewModel()
        {
            return new CategoryViewModelAdmin
            {
                Id = 1,
                Name = "category name"
            };
        }

        internal static BrandViewModelAdmin GetAdminBrandViewModel()
        {
            return new BrandViewModelAdmin
            {
                Id = 1,
                Name = "brand name",
                WebSite = "website name"
            };
        }

        internal static TopicViewModelAdmin GetAdminTopicViewModel()
        {
            return new TopicViewModelAdmin
            {
                Id = 1,
                Name = "topic name",
                Description = "topic description"
            };
        }

        internal static SupplementViewModelAdmin GetAdminSupplementViewModel()
        {
            return new SupplementViewModelAdmin
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

        internal static Topic GetTopicWithComments()
        {
            return new Topic
            {
                Id = 1,
                Name = "topic name",
                Description = "topic description",
                Comments = new List<Comment>()
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

        internal static Brand GetBrand()
        {
            return new Brand
            {
                Id = 1,
                Name = "brand name",
                WebSite = "brand website"
            };
        }

        internal static IList<BrandViewModel> GetCommonBrandsCollection()
        {
            IList<BrandViewModel> brands = new List<BrandViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                brands.Add(new BrandViewModel
                {
                    Id = i,
                    Name = "test brand name" + i,
                    WebSite = "test brand website" + i,
                });
            }

            return brands;
        }

        internal static IQueryable<TopicViewModel> GetCommonTopicsColection()
        {
            List<TopicViewModel> topics = new List<TopicViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                topics.Add(new TopicViewModel
                {
                    Id = i,
                    Name = "test topic name" + i,
                    Description = "test topic description" + i
                });
            }

            return topics.AsQueryable();
        }

        internal static IQueryable<CategoryViewModel> GetCommonCategoriesCollection()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new CategoryViewModel
                {
                    Id = i,
                    Name = "test category name" + i
                });
            }

            return categories.AsQueryable();
        }

        internal static IQueryable<SupplementViewModel> GetCommonSupplementsCollection()
        {
            List<SupplementViewModel> supplements = new List<SupplementViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                supplements.Add(new SupplementViewModel
                {
                    Id = i,
                    ImageUrl = "test supplement image url" + i,
                    Name = "test supplement name" + i
                });
            }

            return supplements.AsQueryable();
        }

        internal static IEnumerable<SelectListItem> GetSessionCategories()
        {
            IList<SelectListItem> sessionCategories = new List<SelectListItem>();

            for (int i = 1; i <= 10; i++)
            {
                sessionCategories.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = "test session category" + i
                });
            }

            return sessionCategories;
        }

        internal static IEnumerable<SelectListItem> GetSessionTopics()
        {
            IList<SelectListItem> sessionTopics = new List<SelectListItem>();

            for (int i = 1; i <= 10; i++)
            {
                sessionTopics.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = "test session topic" + i
                });
            }

            return sessionTopics;
        }

        internal static IEnumerable<SelectListItem> GetSessionBrands()
        {
            IList<SelectListItem> sessionBrands = new List<SelectListItem>();

            for (int i = 1; i <= 10; i++)
            {
                sessionBrands.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = "test session brand" + i
                });
            }

            return sessionBrands;
        }

        internal static FeedbackViewModel GetFeedbackViewModel()
        {
            return new FeedbackViewModel
            {
                Title = "test feedback title",
                Content = "test feedback content"
            };
        }

        internal static PostCommentViewModel GetPostCommentViewModel()
        {
            return new PostCommentViewModel
            {
                TopicId = 1,
                Content = "test comment content"
            };
        }

        internal static IList<HomeTopicViewModel> GetHomeTopicViewModelCollection()
        {
            IList<HomeTopicViewModel> topicsCollection = new List<HomeTopicViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                topicsCollection.Add(new HomeTopicViewModel
                {
                    Id = i,
                    Name = "home topic name" + i,
                    Description = "home topic description" + i
                });
            }

            return topicsCollection;
        }
    }
}

﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Data
{
    public interface IFoodSupplementsSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Supplement> Supplements { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Topic> Topics { get; set; }

        IDbSet<Brand> Brands { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Feedback> Feedbacks { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

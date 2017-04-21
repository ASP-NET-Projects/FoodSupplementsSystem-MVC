﻿using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetLast3();

        Category Create(string name);

        void UpdateNameById(int id, string name);

        void DeleteById(int id);

        Category GetById(int id);
    }
}

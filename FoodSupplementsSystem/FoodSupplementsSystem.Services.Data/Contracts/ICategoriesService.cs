using FoodSupplementsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category Create(string name);

        void UpdateNameById(int id, string name);

        void DeleteById(int id);

        Category GetById(int id);
    }
}

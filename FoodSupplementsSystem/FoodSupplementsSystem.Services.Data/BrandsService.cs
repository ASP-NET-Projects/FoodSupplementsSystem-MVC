﻿using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class BrandsService : IBrandsService
    {
        private IEfGenericRepository<Brand> brands;

        public BrandsService(IEfGenericRepository<Brand> brands)
        {
            Guard.WhenArgument(brands, "brands").IsNull().Throw();

            this.brands = brands;
        }

        public IQueryable<Brand> GetAll()
        {
            return this.brands.All();
        }

        public IQueryable<Brand> GetLast3()
        {
            return this.brands.Last3();
        }

        public Brand GetById(int id)
        {
            return this.brands.GetById(id);
        }

        public Brand Create(string name, string website)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(website, "website").IsNullOrEmpty().Throw();

            var brand = new Brand() { Name = name, WebSite = website };

            this.brands.Add(brand);

            this.brands.SaveChanges();

            return brand;
        }

        public void UpdateById(int id, string name, string website)
        {
            Guard.WhenArgument(id, "id").IsLessThan(0).Throw();

            Guard.WhenArgument(name, "name").IsNull().Throw();

            this.brands.GetById(id).Name = name;

            this.brands.GetById(id).WebSite = website;

            this.brands.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.brands.Delete(id);
            this.brands.SaveChanges();
        }
    }
}

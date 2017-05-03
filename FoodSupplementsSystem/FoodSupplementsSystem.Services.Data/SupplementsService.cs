using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class SupplementsService : ISupplementsService
    {
        private IEfGenericRepository<Supplement> supplements;

        public SupplementsService(IEfGenericRepository<Supplement> supplements)
        {
            Guard.WhenArgument(supplements, "supplements").IsNull().Throw();

            this.supplements = supplements;
        }

        public IQueryable<Supplement> GetAll()
        {
            return this.supplements.All();
        }

        public IQueryable<Supplement> GetLast3()
        {
            return this.supplements.Last3();
        }

        public Supplement GetById(int id)
        {
            return this.supplements.GetById(id);
        }

        public void Create(Supplement supplement)
        {
            Guard.WhenArgument(supplement, "supplement").IsNull().Throw();

            this.supplements.Add(supplement);
            this.supplements.SaveChanges();
        }

        public Supplement Create(string name, string imageUrl, string ingredients, string use, string description)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            var supplement = new Supplement() { Name = name, ImageUrl = imageUrl, Ingredients = ingredients, Use = use, Description = description };

            this.supplements.Add(supplement);

            this.supplements.SaveChanges();

            return supplement;
        }

        public void UpdateById(int id, string name, string imageUrl, string ingredients, string use, string description)
        {
            Guard.WhenArgument(id, "id").IsLessThan(0).Throw();

            Guard.WhenArgument(name, "name").IsNull().Throw();

            this.supplements.GetById(id).Name = name;
            this.supplements.GetById(id).ImageUrl = imageUrl;
            this.supplements.GetById(id).Ingredients = ingredients;
            this.supplements.GetById(id).Use = use;
            this.supplements.GetById(id).Description = description;

            this.supplements.SaveChanges();
        }

        public void DeleteById(int id)
        {
            //Guard.WhenArgument(id, "id").IsLessThan(0).Throw();

            this.supplements.Delete(id);

            this.supplements.SaveChanges();
        }
    }
}

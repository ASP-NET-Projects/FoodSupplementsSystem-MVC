using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class SupplementsService : ISupplementsService
    {
        private readonly IEfGenericRepository<Supplement> supplements;

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
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            return this.supplements.GetById(id);
        }

        public void Create(Supplement supplement)
        {
            Guard.WhenArgument(supplement, "supplement").IsNull().Throw();

            this.supplements.Add(supplement);
            this.supplements.SaveChanges();
        }

        public void Update(Supplement supplement)
        {
            Guard.WhenArgument(supplement, "supplement").IsNull().Throw();

            this.supplements.Update(supplement);
            this.supplements.SaveChanges();
        }

        public void Delete(Supplement supplement)
        {
            Guard.WhenArgument(supplement, "supplement").IsNull().Throw();

            this.supplements.Delete(supplement);
            this.supplements.SaveChanges();
        }
    }
}

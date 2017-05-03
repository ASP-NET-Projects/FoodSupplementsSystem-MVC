using System;
using System.Linq;

namespace FoodSupplementsSystem.Data.Repositories
{
    public interface IEfGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Last3();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        int SaveChanges();
    }
}

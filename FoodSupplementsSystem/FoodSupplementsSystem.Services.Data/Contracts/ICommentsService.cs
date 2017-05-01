using System.Linq;

using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();

        void Create(Comment comment);
    }
}
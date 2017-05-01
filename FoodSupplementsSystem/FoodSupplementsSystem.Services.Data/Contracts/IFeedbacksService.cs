using System.Linq;

using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface IFeedbacksService
    {
        IQueryable<Feedback> GetAll();

        void Create(Feedback feedback);
    }
}
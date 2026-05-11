using Api.Models;

namespace Api.Services
{
    public interface IOrderRepository
    {
        void Save(IOrder order);
    }
}
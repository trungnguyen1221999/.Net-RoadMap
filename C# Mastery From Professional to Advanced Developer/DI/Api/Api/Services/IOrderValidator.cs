using Api.Models;

namespace Api.Services
{
    public interface IOrderValidator
    {
        void Validate(IOrder order);
    }
}
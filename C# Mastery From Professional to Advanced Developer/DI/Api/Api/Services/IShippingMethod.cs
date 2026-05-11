using Api.Models;

namespace Api.Services
{
    public interface IShippingMethod
    {
        void Ship(IOrder order);
    }
}

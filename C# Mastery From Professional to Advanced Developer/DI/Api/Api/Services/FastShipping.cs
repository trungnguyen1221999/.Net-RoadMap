using Api.Models;

namespace Api.Services
{
    public class FastShipping : IShippingMethod
    {
        public void Ship(IOrder order)
        {
            // Simulate fast shipping logic
            Console.WriteLine($"Order {order.Id} is being shipped with Fast Shipping.");
        }
    }
}

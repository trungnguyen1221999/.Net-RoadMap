using Api.Models;

namespace Api.Services
{
    public class CarefulShipping : IShippingMethod
    {
        public void Ship(IOrder order)
        {
            // Simulate small package shipping logic
            Console.WriteLine($"Order {order.Id} is being shipped with extra carefully.");
        }
    }
}

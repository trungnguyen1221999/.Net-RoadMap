using Api.Models;

namespace Api.Services
{
    public class LargePackageShipping : IShippingMethod
    {
        public void Ship(IOrder order)
        {
            // Simulate small package shipping logic
            Console.WriteLine($"Order {order.Id} is being shipped with Large Package Shipping.");
        }
    }
}

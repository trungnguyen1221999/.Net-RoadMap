using Api.Models;

namespace Api.Services
{
    public class SmallPackageShipping : IShippingMethod
    {
        public void Ship(IOrder order)
        {
            // Simulate small package shipping logic
            Console.WriteLine($"Order {order.Id} is being shipped with Small Package Shipping.");
        }
    }
}

using Api.Models;

namespace Api.Services
{
    public class OrderRepository : IOrderRepository
    {
        public void Save(IOrder order)
        {
            // Simulate saving the order to a database
            Console.WriteLine(
                $"Order saved: {order.UserEmail} ordered {order.Qty} of {order.ProductName}"
            );
        }
    }
}

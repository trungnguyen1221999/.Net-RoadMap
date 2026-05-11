using Api.Models;

namespace Api.Services
{
    public class OrderValidator : IOrderValidator
    {
        public void Validate(IOrder order)
        {
            if (string.IsNullOrEmpty(order.UserEmail))
                throw new ArgumentException("User email is required.");

            if (string.IsNullOrEmpty(order.ProductName))
                throw new ArgumentException("Product name is required.");

            if (order.Qty <= 0)
                throw new ArgumentException("Quantity must be a positive integer.");
        }
    }
}
public interface ISendEmail
{
    void SendEmail(string email, string message);
}

public interface IOrderRepository
{
    void SaveOrder(string email, string productName, int qty);
}

public class OrderService
{
    private readonly ISendEmail _sendEmail;
    private readonly IOrderRepository _orderRepository;

    public OrderService(ISendEmail sendEmail, IOrderRepository orderRepository)
    {
        _sendEmail = sendEmail;
        _orderRepository = orderRepository;
    }

    public void PlaceOrder(string email, string productName, int qty)
    {
        if (qty <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }
        _orderRepository.SaveOrder(email, productName, qty);
        _sendEmail.SendEmail(email, $"Your order for {qty} {productName} has been placed.");
    }
}
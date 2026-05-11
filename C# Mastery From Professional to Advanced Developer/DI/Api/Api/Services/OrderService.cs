using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShippingMethod _shippingMethod;
        private readonly INotificationService _notificationService;
        private readonly IOrderValidator _orderValidator;

        public OrderService(
            IOrderRepository orderRepository,
            IShippingMethod shippingMethod,
            INotificationService notificationService,
            IOrderValidator orderValidator
        )
        {
            _orderRepository = orderRepository;
            _shippingMethod = shippingMethod;
            _notificationService = notificationService;
            _orderValidator = orderValidator;
        }

        public void PlaceOrder(OrderRequest order)
        {
            order.Id = Guid.NewGuid();
            _orderValidator.Validate(order);
            _orderRepository.Save(order);
            _shippingMethod.Ship(order);
            _notificationService.sendNotification(order.UserEmail, "Place Order Successfully");
        }
    }
}
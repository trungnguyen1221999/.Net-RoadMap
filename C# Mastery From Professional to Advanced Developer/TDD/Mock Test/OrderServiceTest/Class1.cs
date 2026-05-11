using Moq;
using Xunit;

public class OrderServiceTest
{
    [Fact]
    public void PlaceOrder_WhenQuantityIsZero_ShouldThrowArgumentException()
    {
        // Arrange
        var sendEmailMock = new Mock<ISendEmail>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var orderService = new OrderService(sendEmailMock.Object, orderRepositoryMock.Object);
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            orderService.PlaceOrder("abc@gmail.com", "ProductA", 0)
        );
        //Repository and Email should not be called
        orderRepositoryMock.Verify(
            r => r.SaveOrder(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()),
            Times.Never
        );
    }

    [Fact]
    public void PlaceOrder_WhenValíd_ShouldSaveOrderAndSendEmail()
    {
        // Arrange
        var sendEmailMock = new Mock<ISendEmail>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var orderService = new OrderService(sendEmailMock.Object, orderRepositoryMock.Object);
        // Act
        orderService.PlaceOrder("abc@gmail.com", "ProductA", 2);

        // Assert
        orderRepositoryMock.Verify(r => r.SaveOrder("abc@gmail.com", "ProductA", 2), Times.Once);

        sendEmailMock.Verify(
            e => e.SendEmail("abc@gmail.com", "Your order for 2 ProductA has been placed."),
            Times.Once
        );
    }
}
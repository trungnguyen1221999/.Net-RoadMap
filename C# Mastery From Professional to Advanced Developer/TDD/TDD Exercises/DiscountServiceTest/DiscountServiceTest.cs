using Xunit;

public class DiscountServiceTest
{
    [Fact]
    public void CalculateDiscount_WhenPriceLessThan1M_ReturnZero()
    {
        // Arrange
        var discountService = new DiscountService();
        // Act
        var result = discountService.CalculateDiscount(999999);
        // Assert

        Assert.Equal(0, result);
    }

    [Fact]
    public void CalculateDiscount_WhenPriceOver1M_ReturnFive()
    {
        // Arrange
        var discountService = new DiscountService();
        // Act
        var result = discountService.CalculateDiscount(1000000);
        // Assert
        Assert.Equal(5, result);
    }
}
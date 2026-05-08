using Xunit;

public class StringCalculatorTests
{
    [Fact]
    public void Add_WhenEmptyString_ReturnsZero()
    {
        var calc = new StringCalculator();
        int result = calc.Add("");
        Assert.Equal(0, result);
    }

    [Fact]
    public void Add_WhenSingleNumber_ReturnsThatNumber()
    {
        var calc = new StringCalculator();
        int result = calc.Add("5");
        Assert.Equal(5, result);
    }

    [Fact]
    public void Add_WhenMultipleNumbers_ReturnsTheirSum()
    {
        var calc = new StringCalculator();
        int result = calc.Add("1,2,3");
        Assert.Equal(6, result);
    }
}
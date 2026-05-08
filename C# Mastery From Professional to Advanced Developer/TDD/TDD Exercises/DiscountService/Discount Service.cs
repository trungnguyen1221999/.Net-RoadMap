public class DiscountService
{
    public decimal Discount { get; private set; }

    public int CalculateDiscount(decimal price)
    {
        if (price < 1000000)
            return 0;
        else
            return 5;
    }
}
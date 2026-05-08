public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        return numbers.Split(',').Select(int.Parse).Sum();
    }
}
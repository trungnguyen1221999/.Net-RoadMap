//Viết một StockMarket(subject).Khi giá cổ phiếu thay đổi → thông báo tới:

//InvestorObserver — in ra "Investor {name}: price changed to {price}"
//BotObserver — in ra "Bot triggered: auto-sell at {price}"

public interface IObserver
{
    void Update(decimal newPrice);
}

public class InvestorObserver : IObserver
{
    private string _name;

    public InvestorObserver(string name)
    {
        _name = name;
    }

    public void Update(decimal newPrice)
    {
        Console.WriteLine($"Investor {_name}: price changed to {newPrice}");
    }
}

public class BotObserver : IObserver
{
    public void Update(decimal newPrice)
    {
        Console.WriteLine($"Bot triggered: auto-sell at {newPrice}");
    }
}

public class StockMarket
{
    private decimal _currentPrice;
    private List<IObserver> _subscribers = new();

    public void AddSubscriber(IObserver subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void RemoveSubscriber(IObserver subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void PriceChange(decimal newPrice)
    {
        if (newPrice != _currentPrice)
        {
            _currentPrice = newPrice;
            NotifyPriceChange(newPrice);
        }
    }

    public void NotifyPriceChange(decimal newPrice)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(newPrice);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StockMarket stockMarket = new StockMarket();
        InvestorObserver investor1 = new InvestorObserver("Investor 1");
        InvestorObserver investor2 = new InvestorObserver("Investor 2");
        BotObserver botObserver = new BotObserver();
        botObserver.Update(200m);
        stockMarket.AddSubscriber(investor1);
        stockMarket.AddSubscriber(investor2);
        stockMarket.AddSubscriber(botObserver); // thêm bot vào

        stockMarket.PriceChange(100m);
        stockMarket.PriceChange(150m);

        stockMarket.RemoveSubscriber(botObserver); // bot unsubscribe
        stockMarket.PriceChange(200m); // chỉ investor nhận

        stockMarket.PriceChange(100m);
        stockMarket.PriceChange(100m);
        stockMarket.PriceChange(100m);
        stockMarket.PriceChange(100m);
        stockMarket.PriceChange(100m);
        stockMarket.PriceChange(100m);
        stockMarket.PriceChange(150m);
        stockMarket.PriceChange(200m);

        stockMarket.RemoveSubscriber(investor1);
        stockMarket.PriceChange(200m);
        stockMarket.PriceChange(250m);
    }
}
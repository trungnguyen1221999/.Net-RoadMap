//Viết Factory tạo các loại INotification:

//EmailNotification — in ra "Sending email: {message}"
//SmsNotification — in ra "Sending SMS: {message}"
//PushNotification — in ra "Sending push: {message}"

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending push: {message}");
    }
}

public class OtherNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending from other: {message}");
    }
}

public class NotificationFactory
{
    public static readonly Dictionary<string, Func<INotification>> notificationCreators =
        new Dictionary<string, Func<INotification>>()
        {
            { "email", () => new EmailNotification() },
            { "sms", () => new SmsNotification() },
            { "push", () => new PushNotification() },
        };

    public static void RegisterNotification(string type, Func<INotification> creator)
    {
        notificationCreators[type] = creator;
    }

    public static INotification CreateNotification(string type)
    {
        if (notificationCreators.TryGetValue(type, out var creator))
        {
            return creator();
        }
        else
        {
            return new OtherNotification();
        }
    }
}

public class Program
{
    public static void Main()
    {
        var emailNotification = NotificationFactory.CreateNotification("email");
        emailNotification.Send("Hello via Email!");
        var smsNotification = NotificationFactory.CreateNotification("sms");
        smsNotification.Send("Hello via SMS!");
        var pushNotification = NotificationFactory.CreateNotification("push");
        pushNotification.Send("Hello via Push!");

        NotificationFactory.RegisterNotification("abc", () => new OtherNotification());
        var otherNotification = NotificationFactory.CreateNotification("abc");
        otherNotification.Send("Hello via Other!");
    }
}
//using System.Data.SqlClient;
//using System.Net.Mail;

//public class OrderService
//{
//    public void PlaceOrder(string productName, int quantity, string userEmail)
//    {
//        if (quantity <= 0)
//            throw new Exception("Quantity must be greater than 0");

// var conn = new SqlConnection("Server=...;Database=..."); conn.Open(); var cmd = new
// SqlCommand("INSERT INTO Orders VALUES (@p, @q)", conn); cmd.Parameters.AddWithValue("@p",
// productName); cmd.Parameters.AddWithValue("@q", quantity); cmd.ExecuteNonQuery();

// if (productName == "Laptop") Console.WriteLine($"Shipping Laptop to {userEmail} — special
// handling required"); else if (productName == "Phone") Console.WriteLine($"Shipping Phone to {userEmail}");

//        var smtp = new SmtpClient("smtp.gmail.com");
//        smtp.Send("no-reply@shop.com", userEmail, "Order confirmed!", $"You ordered {productName}");
//    }
//}

// TURN THIS SPAGHETTI CODE INTO A BETTER DESIGN USING THE STRATEGY PATTERN

//I can divide this OrderService to 4 parts
//- Validation
//- Connect to database and save order
//- Shipping
//- Send notification

//1. Validation
public interface IOrderValidator
{
    void Validate(string productName, int quantity);
}

public class OrderQuantityValidator : IOrderValidator
{
    public void Validate(string productName, int quantity)
    {
        if (quantity <= 0)
            throw new Exception("Quantity must be greater than 0");
    }
}

//2. Connect to database and save order

public interface IDbService
{
    //Connect to DB
    void Connect(string connectionString);

    //Save order to DB
    void SaveOrder(string productName, int quantity);
}

public class SqlDBService : IDbService
{
    public void Connect(string SqlConnectionString)
    {
        Console.WriteLine(
            "Connect to SQL database using connection string: " + SqlConnectionString
        );
    }

    public void SaveOrder(string productName, int quantity)
    {
        Console.WriteLine($"Saving order to SQL database: {productName} x {quantity}");
    }
}

//3. Shipping
public interface IShippingService
{
    void Ship(string userEmail);
};

public class LaptopShippingService : IShippingService
{
    public void Ship(string userEmail)
    {
        Console.WriteLine($"Shipping Laptop to {userEmail} — special handling required");
    }
};

public class PhoneShippingService : IShippingService
{
    public void Ship(string userEmail)
    {
        Console.WriteLine($"Shipping Phone to {userEmail}");
    }
};

public class TabletShippingService : IShippingService
{
    public void Ship(string userEmail)
    {
        Console.WriteLine($"Shipping Tablet to {userEmail}");
    }
};

//4. Send notification

public interface INotificationService
{
    void Send(string userEmail, string productName, string message);
};

public class EmailNotificationService : INotificationService
{
    public void Send(string userEmail, string productName, string message)
    {
        Console.WriteLine($"Sending email to {userEmail}: {message} about {productName}");
    }
};

public class SmsNotificationService : INotificationService
{
    public void Send(string userEmail, string productName, string message)
    {
        Console.WriteLine($"Sending SMS to {userEmail}: {message} about {productName}");
    }
}

//5. Get Product Shipping Service

public class ShippingService
{
    public IShippingService getProductShippingService(string productName)
    {
        switch (productName)
        {
            case "Laptop":
                return new LaptopShippingService();

            case "Phone":
                return new PhoneShippingService();

            default:
                return new TabletShippingService();
        }
    }
}

// Finally, we can use these services in our OrderService

public class OrderService
{
    private readonly IOrderValidator _validator;
    private readonly IDbService _dbService;
    private readonly INotificationService _notificationService;
    private readonly ShippingService _shippingServiceMethod;

    public OrderService(
        IOrderValidator validator,
        IDbService dbService,
        ShippingService shippingServiceMethod,
        INotificationService notificationService
    )
    {
        _validator = validator;
        _dbService = dbService;
        _shippingServiceMethod = shippingServiceMethod;
        _notificationService = notificationService;
    }

    public void PlaceOrder(string productName, int quantity, string userEmail)
    {
        _validator.Validate(productName, quantity);
        _dbService.Connect("Server=...;Database=...");
        _dbService.SaveOrder(productName, quantity);
        _shippingServiceMethod.getProductShippingService(productName).Ship(userEmail);
        _notificationService.Send(userEmail, productName, "Order confirmed!");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var validator = new OrderQuantityValidator();
        var dbService = new SqlDBService();
        var notificationService = new EmailNotificationService();
        var shippingServiceMethod = new ShippingService();

        var orderService = new OrderService(
            validator,
            dbService,
            shippingServiceMethod,
            notificationService
        );
        orderService.PlaceOrder("Laptop", 1, "kai1nguyen@gmail.com");
        orderService.PlaceOrder("Tablet", 2, "kai2nguyen@gmail.com");
        orderService.PlaceOrder("Phone", 3, "kai3nguyen@gmail.com");
        orderService.PlaceOrder("abc", 4, "kai4nguyen@gmail.com");
    }
}
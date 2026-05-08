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

//I can divide this OrderService to 6 parts
//- Validation
//- Connect to database
//-Place Order
//- Save order to database
//- Shipping for different products
//- Send notification

//1. Validation

public interface IOrderValidator
{
    void Validate(string productName, int quantity) { }
}

public class OrderValidator : IOrderValidator
{
    public void Validate(string productName, int quantity)
    {
        if (quantity <= 0)
            throw new Exception("Quantity must be greater than 0");
        else
            Console.WriteLine("Products are on stock");
    }
}

//2. Connect to database

public interface IDatabaseConnection
{
    void Connect(string connectionString) { }
}

public class PostgresqlConnection : IDatabaseConnection
{
    public void Connect(string postgresqlConnectionString)
    {
        Console.WriteLine("Connected to Postgresql database");
    }
}

//4. Save order to database

public interface IOrderRepository
{
    void SaveOrder(string userEmail, string productName, int quantity) { }
}

public class OrderRepository : IOrderRepository
{
    public void SaveOrder(string userEmail, string productName, int quantity)
    {
        Console.WriteLine($"Order for {quantity} {productName} from {userEmail} saved to database");
    }
}

//5. Shipping for different products

public interface IShippingStrategy
{
    void Ship(string productName, int quantity) { }
}

public class LaptopShipping : IShippingStrategy
{
    public void Ship(string productName, int quantity)
    {
        Console.WriteLine($"Shipping x{quantity} {productName} with special handling");
    }
}

public class TabletShipping : IShippingStrategy
{
    public void Ship(string productName, int quantity)
    {
        Console.WriteLine($"Shipping x{quantity} {productName} with medium package");
    }
}

public class PhoneShipping : IShippingStrategy
{
    public void Ship(string productName, int quantity)
    {
        Console.WriteLine($"Shipping x{quantity} {productName} with small package");
    }
}

public class OtherShipping : IShippingStrategy
{
    public void Ship(string productName, int quantity)
    {
        Console.WriteLine($"Shipping x{quantity} {productName} with normal package");
    }
}

//public class ShippingContext
//{
//    public void ShipProduct(string productName, int quantity)
//    {
//        IShippingStrategy shippingStrategy;
//        switch (productName)
//        {
//            case "Laptop":
//                shippingStrategy = new LaptopShipping();
//                break;

// case "Tablet": shippingStrategy = new TabletShipping(); break;

// case "Phone": shippingStrategy = new PhoneShipping(); break;

//            default:
//                shippingStrategy = new OtherShipping();
//                break;
//        }
//        shippingStrategy.Ship(productName, quantity);
//    }
//}
public class ShippingContext
{
    // Dictionary map tên sản phẩm → công thức tạo shipping strategy
    private readonly Dictionary<string, Func<IShippingStrategy>> _strategies = new()
    {
        { "Laptop", () => new LaptopShipping() },
        { "Tablet", () => new TabletShipping() },
        { "Phone", () => new PhoneShipping() },
    };

    // Muốn thêm "TV" → gọi Register, không sửa ShipProduct
    public void Register(string productName, Func<IShippingStrategy> creator)
    {
        _strategies[productName] = creator;
    }

    public void ShipProduct(string productName, int quantity)
    {
        // TryGetValue — tìm trong Dictionary, nếu không có thì dùng OtherShipping
        var strategy = _strategies.TryGetValue(productName, out var creator)
            ? creator()
            : new OtherShipping();

        strategy.Ship(productName, quantity);
    }
}

//6. Send notification

public interface INotificationService
{
    void SendNotification(string userEmail, string productName) { }
}

public class EmailNotificationService : INotificationService
{
    public void SendNotification(string userEmail, string productName)
    {
        Console.WriteLine($"Sending email to {userEmail} about order of {productName}");
    }
}

public class SMSNotificationService : INotificationService
{
    public void SendNotification(string userEmail, string productName)
    {
        Console.WriteLine($"Sending SMS to {userEmail} about order of {productName}");
    }
}

// OrderService

public class OrderService
{
    private readonly IOrderValidator _orderValidator;
    private readonly IDatabaseConnection _databaseConnection;
    private readonly IOrderRepository _orderRepository;
    private readonly ShippingContext _shippingContext;
    private readonly INotificationService _notificationService;

    public OrderService(
        IOrderValidator orderValidator,
        IDatabaseConnection databaseConnection,
        IOrderRepository orderRepository,
        ShippingContext shippingContext,
        INotificationService notificationService
    )
    {
        _orderValidator = orderValidator;
        _databaseConnection = databaseConnection;
        _orderRepository = orderRepository;
        _shippingContext = shippingContext;
        _notificationService = notificationService;
    }

    public void ConnectToDatabase(string connectionString)
    {
        _databaseConnection.Connect(connectionString);
        Console.WriteLine(
            "-----------------------------------------------------------------------------------"
        );
    }

    public void PlaceOrder(string productName, int quantity, string userEmail)
    {
        _orderValidator.Validate(productName, quantity);
        _orderRepository.SaveOrder(userEmail, productName, quantity);
        _notificationService.SendNotification(userEmail, productName);
        _shippingContext.ShipProduct(productName, quantity);
        Console.WriteLine(
            "-----------------------------------------------------------------------------------"
        );
    }
}

public class Program
{
    public static void Main()
    {
        var shippingContext = new ShippingContext();
        shippingContext.Register("TV", () => new OtherShipping());
        var orderService = new OrderService(
            new OrderValidator(),
            new PostgresqlConnection(),
            new OrderRepository(),
            shippingContext,
            new EmailNotificationService()
        );
        orderService.ConnectToDatabase("Server=...;Database=...");

        orderService.PlaceOrder("Laptop", 1, "email1@gmail.com");
        orderService.PlaceOrder("Phone", 2, "email2@gmail.com");
        orderService.PlaceOrder("Tablet", 3, "email3@gmail.com");
        orderService.PlaceOrder("Bed", 1, "email4@gmail.com");
        orderService.PlaceOrder("TV", 3, "email5@gmail.com");
    }
}
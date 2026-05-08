//Viết một AppConfig Singleton chứa 3 thông tin:

//AppName = "MyApp"
//Version = "1.0.0"
//MaxUsers = 100

//Yêu cầu:

//Chỉ có một instance duy nhất trong toàn app
//Dùng Lazy<T>
//Trong Main gọi AppConfig.Instance hai lần, chứng minh cùng một object

public class AppConfig
{
    public string _appName { get; set; }
    public string _version { get; set; }
    public int _maxUsers { get; set; }
    private static readonly Lazy<AppConfig> _instance = new Lazy<AppConfig>(() => new AppConfig());
    public static AppConfig Instance => _instance.Value;

    private AppConfig()
    {
        _appName = "MyApp";
        _version = "1.0.0";
        _maxUsers = 100;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var config1 = AppConfig.Instance;
        var config2 = AppConfig.Instance;
        Console.WriteLine(
            $"Config1: AppName={config1._appName}, Version={config1._version}, MaxUsers={config1._maxUsers}"
        );
        Console.WriteLine(
            $"Config2: AppName={config2._appName}, Version={config2._version}, MaxUsers={config2._maxUsers}"
        );
        Console.WriteLine($"Are both instances the same? {ReferenceEquals(config1, config2)}");
    }
}
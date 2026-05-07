using System.Reflection;

internal class SampleClass
{
    public int Id { get; set; }

    public string Name { get; set; }

    public void Display()
    {
        Console.WriteLine("This is a sample method.");
    }
}

internal class Program
{
    public static void Main1()
    {
        Type type = typeof(SampleClass);
        Console.WriteLine("Class Name: " + type.Name);
        Console.WriteLine("--------------------------");
        Console.WriteLine("Class Properties: ");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine($"Property: {prop.Name}, Type: {prop.PropertyType}");
        }

        Console.WriteLine("--------------------------");
        Console.WriteLine("Class Method: ");
        foreach (MethodInfo method in type.GetMethods())
        {
            Console.WriteLine($"Method: {method.Name}, Return Type: {method.ReturnType}");
        }
    }
}
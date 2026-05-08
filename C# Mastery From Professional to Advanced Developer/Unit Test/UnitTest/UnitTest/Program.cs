public interface IAnimal
{
    string Name { get; }

    string MakeSound();

    string Eat();

    string Sleep();
}

public class Dog : IAnimal
{
    public string Name { get; } = "Dog";

    public string MakeSound() => "Woof!";

    public string Eat() => "The Dog is eating";

    public string Sleep() => "The dog is sleeping";
}

public class Cat : IAnimal
{
    public string Name { get; } = "Cat";

    public string MakeSound() => "Meow!";

    public string Eat() => "The cat is eating.";

    public string Sleep() => "The cat is sleeping.";
}

public class AnimalFactory
{
    public static IAnimal CreateAnimal(string type)
    {
        return type switch
        {
            "Dog" => new Dog(),
            "Cat" => new Cat(),
            _ => throw new ArgumentException("Invalid animal type"),
        };
    }
}
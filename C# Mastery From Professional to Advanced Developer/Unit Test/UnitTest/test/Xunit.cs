using Xunit;

public class AnimalTests
{
    [Fact]
    public void TestDog()
    {
        var dog = new Dog();
        Assert.NotNull(dog);
        Assert.IsType<Dog>(dog);
        Assert.Equal("Dog", dog.Name);
        Assert.Equal("Woof!", dog.MakeSound());
        Assert.Contains("dog", dog.Sleep().ToLower());
        Assert.Contains("dog", dog.Eat().ToLower());
    }

    [Fact]
    public void TestCat()
    {
        var cat = new Cat();
        Assert.NotNull(cat);
        Assert.IsType<Cat>(cat);
    }

    [Fact]
    public void TestAnimalFactory()
    {
        var dog = AnimalFactory.CreateAnimal("Dog");
        Assert.NotNull(dog);
        Assert.IsType<Dog>(dog);
        var cat = AnimalFactory.CreateAnimal("Cat");
        Assert.NotNull(cat);
        Assert.IsType<Cat>(cat);
    }
}
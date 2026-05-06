using System;
using System.Collections;
using System.Collections.Generic;

public class CustomCollection<T> : IEnumerable<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item) => _items.Add(item);

    public void Remove(T item) => _items.Remove(item);

    public int Count() => _items.Count();

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Program
{
    public static void Main()
    {
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("------------------------------------------------");

        Console.WriteLine("After removing 2:");
        collection.Remove(2);

        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"Count: {collection.Count()}");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

public class CustomCollection<T> : ICollection<T>
{
    private List<T> _items = new List<T>();

    public bool IsReadOnly => false;

    public int Count => _items.Count;

    public void Add(T item) => _items.Add(item);

    public bool Remove(T item) => _items.Remove(item);

    public void Clear() => _items.Clear();

    public bool Contains(T item) => _items.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Program
{
    public static void Main()
    {
        var collection = new CustomCollection<string>();
        collection.Add("C#");
        collection.Add("Javascript");
        collection.Add(".Net");

        Console.WriteLine("=== Danh sach ban dau ===");
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("After removing C#:");
        collection.Remove("C#");

        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"Count: {collection.Count}");

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("After Clear:");
        collection.Clear();
        Console.WriteLine($"Count sau khi Clear: {collection.Count}");
    }
}

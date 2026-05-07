//Create a Custom Collection that stores integers and does not allow duplicate values.
//Add logging functionality when elements are added to or removed from the collection.
//Write unit tests to verify the functionality of the Custom Collection.

using System;
using System.Collections;
using System.Collections.Generic;

public class CustomIntCollection : ICollection<int>
{
    private HashSet<int> _items = new HashSet<int>();
    public int Count => _items.Count;
    public bool IsReadOnly => false;

    public bool Contains(int item) => _items.Contains(item);

    public void Add(int item)
    {
        if (_items.Add(item))
        {
            Console.WriteLine($"Added: {item}");
        }
        else
        {
            Console.WriteLine($"Duplicate not added: {item}");
        }
    }

    public bool Remove(int item)
    {
        if (_items.Remove(item))
        {
            Console.WriteLine($"Removed: {item}");
            return true;
        }
        else
        {
            Console.WriteLine($"Item not found for removal: {item}");
            return false;
        }
    }

    public void Clear() => _items.Clear();

    public void CopyTo(int[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public IEnumerator<int> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Program
{
    public static void Main()
    {
        var collection = new CustomIntCollection();
        collection.Add(1);
        collection.Add(2);
        collection.Add(2); // Duplicate
        collection.Remove(1);
        collection.Remove(3); // Not found
        Console.WriteLine($"Count: {collection.Count}");
    }
}

var range = Enumerable.Range(1, 10);

var firstThree = range.Take(3);
Console.WriteLine("First three elements: " + string.Join(", ", firstThree));

var skipFive = range.Skip(5);
Console.WriteLine("Elements after skipping five: " + string.Join(", ", skipFive));

var evenNumbers = range.Where(n => n % 2 == 0);
Console.WriteLine("Even numbers in the Range: " + string.Join(", ", evenNumbers));

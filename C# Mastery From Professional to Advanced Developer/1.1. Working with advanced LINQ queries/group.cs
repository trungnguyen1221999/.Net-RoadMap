//group by 1 key

var people = new[]
{
    new { Name = "Alice", Age = 30 },
    new { Name = "Bob", Age = 25 },
    new { Name = "Charlie", Age = 30 },
    new { Name = "David", Age = 25 },
    new { Name = "Eve", Age = 35 },
};

var grouped = people.GroupBy(p => p.Age);

foreach (var group in grouped)
{
    Console.WriteLine($"Age Group: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($" - {person.Name}");
    }
}

var groupOfPeopleHasNameAtLeast4Letters = people.Where(p => p.Name.Length >= 4);
Console.WriteLine($"Group of people have name at least 4 letters:");
foreach (var person in groupOfPeopleHasNameAtLeast4Letters)
{
    Console.WriteLine($" - {person.Name}");
}

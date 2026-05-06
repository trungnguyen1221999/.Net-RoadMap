public class Employee
{
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public decimal Salary { get; set; } = decimal.MinValue;
    public string Location { get; set; } = string.Empty;
}

public class Program
{
    public static void Main()
    {
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

        //group by multiple keys
        var employees = new List<Employee>
        {
            new Employee
            {
                Name = "Alice",
                Department = "HR",
                Salary = 30000,
                Location = "New York",
            },
            new Employee
            {
                Name = "Bob",
                Department = "IT",
                Salary = 25000,
                Location = "San Francisco",
            },
            new Employee
            {
                Name = "Charlie",
                Department = "HR",
                Salary = 32000,
                Location = "Hanoi",
            },
            new Employee
            {
                Name = "David",
                Department = "IT",
                Salary = 40000,
                Location = "San Francisco",
            },
            new Employee
            {
                Name = "Eve",
                Department = "Finance",
                Salary = 25000,
                Location = "Tampere",
            },
        };

        //Group by Department and Location
        var groupedEmployees = employees
            .GroupBy(e => new { e.Department, e.Location })
            .Select(g => new
            {
                Department = g.Key.Department,
                Location = g.Key.Location,
                Employees = g.ToList(),
                TotalSalary = g.Sum(e => e.Salary),
            });

        // Print the results
        foreach (var employee in groupedEmployees)
        {
            Console.WriteLine(
                $"Department: {employee.Department}, Location: {employee.Location}, Total Salary: {employee.TotalSalary}"
            );
            foreach (var emp in employee.Employees)
            {
                Console.WriteLine($" - {emp.Name}");
            }
        }
        //group by multiple keys with conditions

        var groupedEmployeesWithCondition = employees
            .GroupBy(e => new { e.Department, e.Location })
            .Where(g => g.Sum(e => e.Salary) >= 50000)
            .Select(g => new
            {
                Department = g.Key.Department,
                Location = g.Key.Location,
                Employees = g.ToList(),
                TotalSalary = g.Sum(e => e.Salary),
            });
        Console.WriteLine(
            $"Group of employees have total salary at least 50000 by Department and Location:"
        );
        foreach (var employee in groupedEmployeesWithCondition)
        {
            Console.WriteLine(
                $"Department: {employee.Department}, Location: {employee.Location}, Total Salary: {employee.TotalSalary}"
            );
            foreach (var emp in employee.Employees)
            {
                Console.WriteLine($" - {emp.Name} - {emp.Salary}");
            }
        }
    }
}

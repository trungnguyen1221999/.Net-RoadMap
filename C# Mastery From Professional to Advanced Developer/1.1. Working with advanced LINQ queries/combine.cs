using System;
using System.Linq;

class Employee
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public decimal Salary { get; set; } = decimal.MinValue;
}

class Department
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

class Program
{
    static void Main()
    {
        //Employee data
        var employees = new List<Employee>
        {
            new Employee
            {
                Id = "E01",
                Name = "Alice",
                DepartmentId = "D01",
                Salary = 30000,
            },
            new Employee
            {
                Id = "E02",
                Name = "Bob",
                DepartmentId = "D02",
                Salary = 25000,
            },
            new Employee
            {
                Id = "E03",
                Name = "Charlie",
                DepartmentId = "D01",
                Salary = 32000,
            },
            new Employee
            {
                Id = "E04",
                Name = "David",
                DepartmentId = "D02",
                Salary = 40000,
            },
            new Employee
            {
                Id = "E05",
                Name = "Eve",
                DepartmentId = "D03",
                Salary = 25000,
            },
            new Employee
            {
                Id = "E06",
                Name = "Frank",
                DepartmentId = "D03",
                Salary = 27000,
            },
            new Employee
            {
                Id = "E07",
                Name = "Grace",
                DepartmentId = "D02",
                Salary = 35000,
            },
            new Employee
            {
                Id = "E08",
                Name = "Heidi",
                DepartmentId = "D01",
                Salary = 31000,
            },
            new Employee
            {
                Id = "E09",
                Name = "Ivan",
                DepartmentId = "D02",
                Salary = 33000,
            },
            new Employee
            {
                Id = "E10",
                Name = "Judy",
                DepartmentId = "D03",
                Salary = 29000,
            },
        };

        //Department data
        var departments = new List<Department>
        {
            new Department { Id = "D01", Name = "HR" },
            new Department { Id = "D02", Name = "IT" },
            new Department { Id = "D03", Name = "Finance" },
        };

        //1. List all employees in the "IT" department, sorted by salary in descending order.

        var itEmployees =
            from employee in employees
            join department in departments on employee.DepartmentId equals department.Id
            where department.Name == "IT"
            select new { EmployeeName = employee.Name, Salary = employee.Salary };
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Employees in IT Department (sorted by salary):");
        foreach (var e in itEmployees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"- {e.EmployeeName}, {e.Salary}");
        }

        //2. Calculate the total salary for each department (by DepartmentId), and print the department name and total salary.

        var groupedSalariesByDeparment =
            from employee in employees
            join department in departments on employee.DepartmentId equals department.Id
            group employee by department.Name into g
            select new
            {
                DepartmentName = g.Key,
                Emplpoyees = g.ToList(),
                TotalSalary = g.Sum(e => e.Salary),
            };

        Console.WriteLine("--------------------------------------------------------------");
        foreach (var g in groupedSalariesByDeparment)
        {
            Console.WriteLine($"Department: {g.DepartmentName}, Total Salary: {g.TotalSalary}");
            foreach (var e in g.Emplpoyees)
            {
                Console.WriteLine($"  - {e.Name}, {e.Salary}");
            }
        }
        //3. Find the employee with the highest salary in each department, and print the department name, employee name, and salary.
        Console.WriteLine("--------------------------------------------------------------");
        foreach (var g in groupedSalariesByDeparment)
        {
            Console.WriteLine($"Department: {g.DepartmentName}");
            var highestPaidEmployee = g
                .Emplpoyees.OrderByDescending(e => e.Salary)
                .FirstOrDefault();
            Console.WriteLine(
                $"  - Highest Paid Employee: {highestPaidEmployee?.Name}, Salary: {highestPaidEmployee?.Salary}"
            );
        }
        //4. Perform a join between Employee and Department to print a list of employees with their corresponding department names.
        Console.WriteLine("--------------------------------------------------------------");
        var employeesWithDepartmentNames =
            from employee in employees
            join department in departments on employee.DepartmentId equals department.Id
            select new { EmployeeName = employee.Name, DepartmentName = department.Name };

        foreach (var e in employeesWithDepartmentNames)
        {
            Console.WriteLine($"Employee: {e.EmployeeName}, Department: {e.DepartmentName}");
        }

        //5. Count the number of employees in each department, and print the department name and the employee count.
        Console.WriteLine("--------------------------------------------------------------");
        var employeesCountWithDepartmentNames =
            from employee in employees
            join department in departments on employee.DepartmentId equals department.Id
            group employee by department.Name into g
            select new
            {
                Deparment = g.Key,
                Employees = g.ToList(),
                TotalEmployeesCount = g.Count(),
            };
        foreach (var e in employeesCountWithDepartmentNames)
        {
            Console.WriteLine(
                $"Department: {e.Deparment}, Total Employees Count: {e.TotalEmployeesCount}"
            );
            foreach (var employee in e.Employees)
            {
                Console.WriteLine($"  - {employee.Name}");
            }
        }
    }
}

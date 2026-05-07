//Write a program using Reflection to inspect all properties and methods in a class, including private members.
//Modify the value of a private field and check whether the change takes effect.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reflection
{
    internal class Excercise
    {
        public static void Main()
        {
            Type type = typeof(Person);
            Console.WriteLine("Class Name :" + type.Name);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Class Properties: ");

            foreach (PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine($"- {property.Name}, Type: {property.PropertyType}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Class Method: ");

            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine($"- {method.Name}, Type: {method.ReturnType}");
            }
            object instance = Activator.CreateInstance(type);
            PropertyInfo nameProperty = type.GetProperty("Name");
            nameProperty?.SetValue(instance, "Kai");

            FieldInfo privateSalary = type.GetField(
                "_salary",
                BindingFlags.NonPublic | BindingFlags.Instance
            );
            privateSalary?.SetValue(instance, 5000M);

            MethodInfo getSalaryMethod = type.GetMethod("getSalary");
            getSalaryMethod?.Invoke(instance, null);
        }
    }

    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private decimal _salary = 1000M;

        public void getSalary()
        {
            Console.WriteLine($"{Name}'s Salary: {_salary}");
        }
    }
}
using Task_1;
using Task_1.Models;

Person[] people = new Person[]
{
    new Person { Name = "John", Age = 30 },
    new Person { Name = "Alice", Age = 25 },
    new Person { Name = "Bob", Age = 35 },
    new Person { Name = "Bobby", Age = 31 },
    new Person { Name = "Alice2", Age = 25 },
};

int[] intArray = new int[1000].Select(x => x = new Random().Next(0, 10001)).ToArray();

// Define the custom comparison function
Func<Person, Person, int> comparison = (x, y) => x.Age.CompareTo(y.Age);

Func<int, int, int> comparisonInt = (x, y) => x.CompareTo(y);

// Sort the array using QuickSort
QuickSort<Person>.SortRecursive(people, comparison, PivotType.Last);

QuickSort<int>.SortRecursive(intArray, comparisonInt, PivotType.Median);

// Print the sorted array
foreach (Person person in people)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}

foreach (int val in intArray)
{
    Console.WriteLine(val);
}



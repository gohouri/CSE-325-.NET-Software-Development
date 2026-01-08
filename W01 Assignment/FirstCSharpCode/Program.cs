// First C# Code - Reviewing C# Syntax Basics

// Variables and Data Types
string name = "C# Developer";
int age = 25;
double height = 5.9;
bool isStudent = true;

Console.WriteLine("=== Variables and Data Types ===");
Console.WriteLine($"Name: {name}, Age: {age}, Height: {height}, Is Student: {isStudent}");

// Arrays
int[] numbers = { 1, 2, 3, 4, 5 };
string[] languages = { "C#", "Python", "JavaScript" };

Console.WriteLine("\n=== Arrays ===");
Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");
Console.WriteLine($"Languages: {string.Join(", ", languages)}");

// Control Flow - If/Else
Console.WriteLine("\n=== Control Flow ===");
if (age >= 18)
{
    Console.WriteLine("You are an adult.");
}
else
{
    Console.WriteLine("You are a minor.");
}

// Loops
Console.WriteLine("\n=== Loops ===");
Console.WriteLine("For loop:");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"  Iteration {i + 1}");
}

Console.WriteLine("Foreach loop:");
foreach (string lang in languages)
{
    Console.WriteLine($"  Language: {lang}");
}

// Methods
Console.WriteLine("\n=== Methods ===");
int result = AddNumbers(10, 20);
Console.WriteLine($"Sum of 10 and 20: {result}");

string greeting = GetGreeting("Alice");
Console.WriteLine(greeting);

// Classes and Objects
Console.WriteLine("\n=== Classes and Objects ===");
Person person = new Person("John", 30);
person.DisplayInfo();

// Static method
Console.WriteLine($"\nStatic method result: {Calculator.Multiply(5, 6)}");

// Method definitions
static int AddNumbers(int a, int b)
{
    return a + b;
}

static string GetGreeting(string name)
{
    return $"Hello, {name}!";
}

// Class definition
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Person: {Name}, Age: {Age}");
    }
}

// Static class
static class Calculator
{
    public static int Multiply(int a, int b)
    {
        return a * b;
    }
}

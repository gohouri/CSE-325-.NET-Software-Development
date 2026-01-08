// Introduction to .NET - Understanding .NET and building a small app

using System;

namespace IntroductionToDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Introduction to .NET ===");
            Console.WriteLine($"Runtime Version: {Environment.Version}");
            Console.WriteLine($"OS Version: {Environment.OSVersion}");
            Console.WriteLine($"Machine Name: {Environment.MachineName}");
            
            // Simple calculator app
            Console.WriteLine("\n=== Simple Calculator ===");
            CalculatorApp.Run();
        }
    }

    class CalculatorApp
    {
        public static void Run()
        {
            Console.WriteLine("Enter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Enter operation (+, -, *, /):");
            string operation = Console.ReadLine() ?? "+";
            
            double result = operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
                _ => throw new InvalidOperationException("Invalid operation")
            };
            
            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
        }
    }
}

// Create a new .NET project and work with dependencies
// Using NuGet packages to develop .NET applications faster

using Newtonsoft.Json;

// Example: Working with JSON using Newtonsoft.Json package
var person = new Person
{
    Name = "John Doe",
    Age = 30,
    Email = "john.doe@example.com"
};

// Serialize object to JSON
string json = JsonConvert.SerializeObject(person, Formatting.Indented);
Console.WriteLine("=== Serialized JSON ===");
Console.WriteLine(json);

// Deserialize JSON to object
string jsonString = @"{
    ""Name"": ""Jane Smith"",
    ""Age"": 25,
    ""Email"": ""jane.smith@example.com""
}";

Person? deserializedPerson = JsonConvert.DeserializeObject<Person>(jsonString);
Console.WriteLine("\n=== Deserialized Object ===");
Console.WriteLine($"Name: {deserializedPerson?.Name}");
Console.WriteLine($"Age: {deserializedPerson?.Age}");
Console.WriteLine($"Email: {deserializedPerson?.Email}");

// Working with a list
var people = new List<Person>
{
    new Person { Name = "Alice", Age = 28, Email = "alice@example.com" },
    new Person { Name = "Bob", Age = 32, Email = "bob@example.com" },
    new Person { Name = "Charlie", Age = 24, Email = "charlie@example.com" }
};

string peopleJson = JsonConvert.SerializeObject(people, Formatting.Indented);
Console.WriteLine("\n=== List of People (JSON) ===");
Console.WriteLine(peopleJson);

class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
}

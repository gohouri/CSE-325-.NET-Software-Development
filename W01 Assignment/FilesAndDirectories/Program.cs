// Work with files and directories in a .NET app
// Includes sales summary report generation

using System.Text;

string dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SalesData");
Directory.CreateDirectory(dataDirectory);

// Create sample sales files
CreateSampleSalesFiles(dataDirectory);

// Read and process sales files
ProcessSalesFiles(dataDirectory);

// Generate sales summary report
GenerateSalesSummaryReport(dataDirectory);

static void CreateSampleSalesFiles(string directory)
{
    // Create sample sales data files
    string[] fileNames = { "sales_january.txt", "sales_february.txt", "sales_march.txt" };
    decimal[] salesAmounts = { 125000.50m, 187500.75m, 225000.25m };

    for (int i = 0; i < fileNames.Length; i++)
    {
        string filePath = Path.Combine(directory, fileNames[i]);
        File.WriteAllText(filePath, $"Total Sales: {salesAmounts[i]:C}");
        Console.WriteLine($"Created file: {filePath}");
    }
}

static void ProcessSalesFiles(string directory)
{
    Console.WriteLine("\n=== Processing Sales Files ===");
    
    string[] files = Directory.GetFiles(directory, "*.txt");
    
    foreach (string file in files)
    {
        string content = File.ReadAllText(file);
        Console.WriteLine($"File: {Path.GetFileName(file)}");
        Console.WriteLine($"Content: {content}");
        Console.WriteLine($"Size: {new FileInfo(file).Length} bytes");
        Console.WriteLine($"Last Modified: {File.GetLastWriteTime(file)}");
        Console.WriteLine();
    }
}

static void GenerateSalesSummaryReport(string directory)
{
    Console.WriteLine("=== Generating Sales Summary Report ===");
    
    string[] files = Directory.GetFiles(directory, "sales_*.txt");
    decimal totalSales = 0;
    var salesDetails = new List<(string filename, decimal amount)>();
    
    // Read sales from each file
    foreach (string file in files)
    {
        string content = File.ReadAllText(file);
        string filename = Path.GetFileName(file);
        
        // Extract sales amount from content (format: "Total Sales: $xxx,xxx.xx")
        decimal salesAmount = ExtractSalesAmount(content);
        totalSales += salesAmount;
        salesDetails.Add((filename, salesAmount));
    }
    
    // Build report using StringBuilder
    StringBuilder report = new StringBuilder();
    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($" Total Sales: {totalSales:C}");
    report.AppendLine();
    report.AppendLine(" Details:");
    
    foreach (var (filename, amount) in salesDetails)
    {
        report.AppendLine($"  {filename}: {amount:C}");
    }
    
    // Write report to file
    string reportPath = Path.Combine(directory, "sales_summary.txt");
    File.WriteAllText(reportPath, report.ToString());
    
    // Display report
    Console.WriteLine(report.ToString());
    Console.WriteLine($"Report saved to: {reportPath}");
}

static decimal ExtractSalesAmount(string content)
{
    // Extract decimal value from content like "Total Sales: $125,000.50"
    // Simple extraction - in real scenario might use regex
    string[] parts = content.Split('$');
    if (parts.Length > 1)
    {
        string amountStr = parts[1].Trim();
        // Remove commas and parse
        amountStr = amountStr.Replace(",", "");
        if (decimal.TryParse(amountStr, out decimal amount))
        {
            return amount;
        }
    }
    return 0;
}

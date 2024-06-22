using ServiceLevelAgreement.Domain;
using ServiceLevelAgreement.Domain.Strategy;

Console.Write("Enter the start date (format YYYY-MM-DD HH:MM:SS): ");

string startDateInput = Console.ReadLine();
DateTime startDate;

// Parse start date and check for valid format
if (!DateTime.TryParse(startDateInput, out startDate))
{
    Console.WriteLine("Invalid start date!");
    return; 
}

Console.Write("Enter the end date (format YYYY-MM-DD HH:MM:SS): ");

string endDateInput = Console.ReadLine();
DateTime endDate;

// Parse end date and check for valid format
if (!DateTime.TryParse(endDateInput, out endDate))
{
    Console.WriteLine("Invalid end date!");
    return; 
}

// Create a calculator using the business hours strategy
var calculator = new CalculatorStrategy(new BusinessHoursCalculator());

// Calculate business hours difference
TimeSpan result = calculator.Calculate(startDate, endDate);

// Output the result
Console.WriteLine($"The total business hours between the given dates is: {result.TotalHours}");
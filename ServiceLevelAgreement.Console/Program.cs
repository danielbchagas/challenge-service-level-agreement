using ServiceLevelAgreement.Domain;
using ServiceLevelAgreement.Domain.BusinessRules;
using ServiceLevelAgreement.Domain.GangOfFour.Behavioral.Strategy;
using ServiceLevelAgreement.Domain.GangOfFour.Creational.FactoryMethod;

Console.Write("Enter the start date (format YYYY-MM-DD HH:MM:SS): ");
string startDateInput = Console.ReadLine();

Console.Write("Enter the end date (format YYYY-MM-DD HH:MM:SS): ");
string endDateInput = Console.ReadLine();

// Create a date range factory
var dateRangeFactory = new DateRangeFactory();
var (start, end) = dateRangeFactory.Create(startDateInput, endDateInput);

// Create a calculator using the business hours strategy
var calculator = new CalculatorStrategyContext(new BusinessHoursCalculator());

// Calculate business hours difference
TimeSpan result = calculator.Calculate(start, end);

// Output the result
Console.WriteLine($"The total business hours between the given dates is: {result.TotalHours}");
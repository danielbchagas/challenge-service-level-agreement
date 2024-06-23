namespace ServiceLevelAgreement.Domain.GangOfFour.Creational.FactoryMethod;

public interface IDateRangeFactory
{
    /// <summary>
    /// Create a date range from the given start and end date strings
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    (DateTime start, DateTime end) Create(string startDate, string endDate);
}

public class DateRangeFactory : IDateRangeFactory
{
    /// <summary>
    /// Create a date range from the given start and end date strings
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public (DateTime start, DateTime end) Create(string startDate, string endDate)
    {
        if (DateTime.TryParse(startDate, out var start) && DateTime.TryParse(endDate, out var end))
        {
            return (start, end);
        }
        
        throw new ArgumentException("Invalid date format!");
    }
}
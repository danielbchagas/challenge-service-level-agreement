using ServiceLevelAgreement.Domain.Constants;

namespace ServiceLevelAgreement.Domain.BusinessRules;

public class BusinessHoursCalculator
{
    /// <summary>
    /// Returns the business hours between two dates
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public TimeSpan Calculate(DateTime start, DateTime end)
    {
        if (start > end)
            throw new ArgumentException(DateTimeMessages.EndDateMustBeGreaterThanStartDate);
        
        var businessHours = new TimeSpan();
        var startHour = 0;
        var endHour = 0;

        for (var date = start.Date; date <= end.Date; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                if (date.Date == start.Date)
                {
                    startHour = start.Hour < 9 ? 9 : (start.Hour > 18 ? 18 : start.Hour);
                    endHour = start.Date == end.Date ? (end.Hour > 18 ? 18 : (end.Hour < 9 ? 9 : end.Hour)) : 18;
                    businessHours += new TimeSpan(endHour - startHour, 0, 0);
                }
                else if (date.Date == end.Date)
                {
                    startHour = 9;
                    endHour = end.Hour > 18 ? 18 : (end.Hour < 9 ? 9 : end.Hour);
                    businessHours += new TimeSpan(endHour - startHour, 0, 0);
                }
                else
                {
                    businessHours += new TimeSpan(9, 0, 0);
                }
            }
        }

        return businessHours;
    }
}
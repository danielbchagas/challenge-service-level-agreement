namespace CalculoSla;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var start = new DateTime(2024, 06, 01, 09, 00, 00);
        var end = new DateTime(2024, 06, 10, 18, 00, 00);

        // Act
        var businessHours = CalculateBusinessHours(start, end);

        // Assert
        Assert.Equal(new TimeSpan(45, 0, 0), businessHours);
    }
    
    private TimeSpan CalculateBusinessHours(DateTime start, DateTime end)
    {
        TimeSpan businessHours = new TimeSpan();

        for (var date = start; date <= end; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                if (date.Date == start.Date)
                {
                    var startHour = start.Hour < 9 ? 9 : start.Hour;
                    var endHour = start.Hour > 18 ? 18 : start.Hour;
                    businessHours += new TimeSpan(endHour - startHour, 0, 0);
                }
                else if (date.Date == end.Date)
                {
                    var startHour = end.Hour < 9 ? 9 : end.Hour;
                    var endHour = end.Hour > 18 ? 18 : end.Hour;
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
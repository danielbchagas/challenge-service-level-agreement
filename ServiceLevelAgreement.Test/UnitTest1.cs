namespace ServiceLevelAgreement;

public class UnitTest1
{
    [Theory]
    [InlineData("2024-05-25 09:00:00", "2024-05-26 18:00:00")] // Weekend
    [InlineData("2024-06-01 09:00:00", "2024-06-01 18:00:00")] // Weekend
    [InlineData("2024-06-02 09:00:00", "2024-06-02 18:00:00")] // Weekend
    [InlineData("2024-06-08 09:00:00", "2024-06-08 18:00:00")] // Weekend
    [InlineData("2024-06-09 09:00:00", "2024-06-09 18:00:00")] // Weekend
    public void Should_Return_ZeroHour(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = CalculateBusinessHours(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(0, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 09:00:00", "2024-06-03 10:00:00")]
    [InlineData("2024-06-04 09:00:00", "2024-06-04 10:00:00")]
    [InlineData("2024-06-05 09:00:00", "2024-06-05 10:00:00")]
    [InlineData("2024-06-06 09:00:00", "2024-06-06 10:00:00")]
    [InlineData("2024-06-07 09:00:00", "2024-06-07 10:00:00")]
    public void Should_Return_OneHour(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = CalculateBusinessHours(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(1, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 09:00:00", "2024-06-03 18:00:00")]
    [InlineData("2024-06-04 09:00:00", "2024-06-04 18:00:00")]
    [InlineData("2024-06-05 09:00:00", "2024-06-05 18:00:00")]
    [InlineData("2024-06-06 09:00:00", "2024-06-06 18:00:00")]
    [InlineData("2024-06-07 09:00:00", "2024-06-07 18:00:00")]
    public void Should_Return_NineHours(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = CalculateBusinessHours(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(09, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 09:00:00", "2024-06-04 18:00:00")]
    [InlineData("2024-06-04 09:00:00", "2024-06-05 18:00:00")]
    [InlineData("2024-06-05 09:00:00", "2024-06-06 18:00:00")]
    [InlineData("2024-06-06 09:00:00", "2024-06-07 18:00:00")]
    [InlineData("2024-06-07 09:00:00", "2024-06-10 18:00:00")]
    public void Should_Return_EighteenHours(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = CalculateBusinessHours(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(18, 0, 0), businessHours);
    }
    
    
    [Theory]
    [InlineData("2024-06-03 17:00:00", "2024-06-04 10:00:00")]
    [InlineData("2024-06-04 17:00:00", "2024-06-05 10:00:00")]
    [InlineData("2024-06-05 17:00:00", "2024-06-06 10:00:00")]
    [InlineData("2024-06-06 17:00:00", "2024-06-07 10:00:00")]
    [InlineData("2024-06-07 17:00:00", "2024-06-10 10:00:00")]
    public void Should_Return_TwoHours_When_StartDay_IsMinorThan_EndDay_And_StartDayHour_IsGreaterThan_EndDayHour(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = CalculateBusinessHours(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(2, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 16:00:00", "2024-06-04 17:00:00")]
    [InlineData("2024-06-04 16:00:00", "2024-06-05 17:00:00")]
    [InlineData("2024-06-05 16:00:00", "2024-06-06 17:00:00")]
    [InlineData("2024-06-06 16:00:00", "2024-06-07 17:00:00")]
    [InlineData("2024-06-07 16:00:00", "2024-06-10 17:00:00")]
    public void Should_Return_TenHours_When_StartDay_IsMinorThan_EndDay_And_StartDayHour_IsGreaterThan_EndDayHour(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = CalculateBusinessHours(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(10, 0, 0), businessHours);
    }
    
    private TimeSpan CalculateBusinessHours(DateTime start, DateTime end)
    {
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
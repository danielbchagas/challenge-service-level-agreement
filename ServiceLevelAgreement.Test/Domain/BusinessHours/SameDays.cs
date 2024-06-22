using Moq;

namespace ServiceLevelAgreement.Domain.BusinessHours;

public class SameDays
{
    private readonly BusinessHoursCalculator _serviceMock;

    public SameDays()
    {
        _serviceMock = new Mock<BusinessHoursCalculator>().Object;
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
        var businessHours = _serviceMock.Calculate(start, end);
    
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
        var businessHours = _serviceMock.Calculate(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(09, 0, 0), businessHours);
    }
}
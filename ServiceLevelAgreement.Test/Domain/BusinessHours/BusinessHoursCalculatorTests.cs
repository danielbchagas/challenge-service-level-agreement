using Moq;
using ServiceLevelAgreement.Domain.BusinessRules;
using ServiceLevelAgreement.Domain.Constants;

namespace ServiceLevelAgreement.Domain.BusinessHours;

public class BusinessHoursCalculatorTests
{
    private readonly BusinessHoursCalculator _serviceMock = new Mock<BusinessHoursCalculator>().Object;

    [Theory]
    [InlineData("2024-05-25 09:00:00", "2024-05-26 18:00:00")]
    [InlineData("2024-06-01 09:00:00", "2024-06-01 18:00:00")]
    [InlineData("2024-06-02 09:00:00", "2024-06-02 18:00:00")]
    [InlineData("2024-06-08 09:00:00", "2024-06-08 18:00:00")]
    [InlineData("2024-06-09 09:00:00", "2024-06-09 18:00:00")]
    public void Should_Return_ZeroHour(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = _serviceMock.Calculate(start, end);
    
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
        var businessHours = _serviceMock.Calculate(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(1, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 17:00:00", "2024-06-04 10:00:00")]
    [InlineData("2024-06-04 17:00:00", "2024-06-05 10:00:00")]
    [InlineData("2024-06-05 17:00:00", "2024-06-06 10:00:00")]
    [InlineData("2024-06-06 17:00:00", "2024-06-07 10:00:00")]
    [InlineData("2024-06-07 17:00:00", "2024-06-10 10:00:00")]
    public void Should_Return_TwoHours(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = _serviceMock.Calculate(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(2, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 09:00:00", "2024-06-03 13:00:00")]
    [InlineData("2024-06-04 09:00:00", "2024-06-04 13:00:00")]
    [InlineData("2024-06-05 09:00:00", "2024-06-05 13:00:00")]
    [InlineData("2024-06-06 09:00:00", "2024-06-06 13:00:00")]
    [InlineData("2024-06-07 09:00:00", "2024-06-07 13:00:00")]
    public void Should_Return_FourHours(DateTime start, DateTime end)
    {
        // Arrange

        // Act
        var businessHours = _serviceMock.Calculate(start, end);

        // Assert
        Assert.Equal(new TimeSpan(4, 0, 0), businessHours);
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
    
    [Theory]
    [InlineData("2024-06-03 16:00:00", "2024-06-04 17:00:00")]
    [InlineData("2024-06-04 16:00:00", "2024-06-05 17:00:00")]
    [InlineData("2024-06-05 16:00:00", "2024-06-06 17:00:00")]
    [InlineData("2024-06-06 16:00:00", "2024-06-07 17:00:00")]
    [InlineData("2024-06-07 16:00:00", "2024-06-10 17:00:00")]
    public void Should_Return_TenHours(DateTime start, DateTime end)
    {
        // Arrange
        
        // Act
        var businessHours = _serviceMock.Calculate(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(10, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 09:00:00", "2024-06-04 12:00:00")]
    [InlineData("2024-06-04 09:00:00", "2024-06-05 12:00:00")]
    [InlineData("2024-06-05 09:00:00", "2024-06-06 12:00:00")]
    [InlineData("2024-06-06 09:00:00", "2024-06-07 12:00:00")]
    [InlineData("2024-06-07 09:00:00", "2024-06-10 12:00:00")]
    public void Should_Return_TwelveHours(DateTime start, DateTime end)
    {
        // Arrange
    
        // Act
        var businessHours = _serviceMock.Calculate(start, end);

        // Assert
        Assert.Equal(new TimeSpan(12, 0, 0), businessHours);
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
        var businessHours = _serviceMock.Calculate(start, end);
    
        // Assert
        Assert.Equal(new TimeSpan(18, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-03 09:00:00", "2024-06-05 15:00:00")]
    [InlineData("2024-06-04 09:00:00", "2024-06-06 15:00:00")]
    [InlineData("2024-06-05 09:00:00", "2024-06-07 15:00:00")]
    [InlineData("2024-06-06 09:00:00", "2024-06-10 15:00:00")]
    [InlineData("2024-06-07 09:00:00", "2024-06-11 15:00:00")]
    public void Should_Return_TwentyFourHours(DateTime start, DateTime end)
    {
        // Arrange
    
        // Act
        var businessHours = _serviceMock.Calculate(start, end);

        // Assert
        Assert.Equal(new TimeSpan(24, 0, 0), businessHours);
    }
    
    [Theory]
    [InlineData("2024-06-02 09:00:00", "2024-06-01 09:00:00")]
    [InlineData("2024-06-03 09:00:00", "2024-06-02 09:00:00")]
    [InlineData("2024-06-04 09:00:00", "2024-06-03 09:00:00")]
    [InlineData("2024-06-05 09:00:00", "2024-06-04 09:00:00")]
    [InlineData("2024-06-06 09:00:00", "2024-06-05 09:00:00")]
    public void Should_Throw_ArgumentException_When_EndDate_IsMinorThan_StartDate(DateTime start, DateTime end)
    {
        // Arrange
        const string expectedMessage = DateTimeMessages.EndDateMustBeGreaterThanStartDate;

        // Act
        var exception = Assert.Throws<ArgumentException>(() => _serviceMock.Calculate(start, end));
        
        // Assert
        Assert.Contains(expectedMessage, exception.Message);
    }
}
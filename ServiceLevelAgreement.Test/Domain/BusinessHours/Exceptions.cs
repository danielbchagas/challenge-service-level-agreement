using Moq;

namespace ServiceLevelAgreement.Domain.BusinessHours;

public class Exceptions
{
    private readonly BusinessHoursCalculator _serviceMock;

    public Exceptions()
    {
        _serviceMock = new Mock<BusinessHoursCalculator>().Object;
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
        
        // Act
        Action action = () => _serviceMock.Calculate(start, end);
    
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}
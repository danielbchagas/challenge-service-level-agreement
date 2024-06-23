namespace ServiceLevelAgreement.Domain.GangOfFour.Behavioral.Strategy;

public interface ICalculatorStrategy
{
    /// <summary>
    /// Calculate the difference between two dates using a specific strategy.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    TimeSpan Calculate(DateTime start, DateTime end);
}

public class CalculatorStrategyContext
{
    private readonly ICalculatorStrategy _strategy;

    public CalculatorStrategyContext(ICalculatorStrategy strategy)
    {
        _strategy = strategy;
    }

    /// <summary>
    /// Calculate the difference between two dates using the specified strategy.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public TimeSpan Calculate(DateTime start, DateTime end)
    {
        return _strategy.Calculate(start, end);
    }
}

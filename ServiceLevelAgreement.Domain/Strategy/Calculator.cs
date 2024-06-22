namespace ServiceLevelAgreement.Domain.Strategy;

public interface ICalculatorStrategy
{
    TimeSpan Calculate(DateTime start, DateTime end);
}

public class CalculatorStrategy
{
    private readonly ICalculatorStrategy _strategy;

    public CalculatorStrategy(ICalculatorStrategy strategy)
    {
        _strategy = strategy;
    }

    public TimeSpan Calculate(DateTime start, DateTime end)
    {
        return _strategy.Calculate(start, end);
    }
}

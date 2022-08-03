﻿using DesignPatternsCSharpNet6.Strategy.Pattern;

namespace Test.DesignPatternsCSharpNet6.StrategyPattern.PatternVersion;

public class TestCalculator
{
    private readonly List<double> _values = 
        new List<double> {10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9};

    [Fact]
    public void Test_AverageByMean()
    {
        Calculator calculator = new Calculator(new AverageByMean());

        var averageByMean = calculator.CalculateAverage(_values);

        Assert.True(ResultsAreCloseEnough(8.3636363, averageByMean));
    }

    [Fact]
    public void Test_AverageByMedian()
    {
        Calculator calculator = new Calculator(new AverageByMedian());

        var averageByMedian = calculator.CalculateAverage(_values);

        Assert.True(ResultsAreCloseEnough(8, averageByMedian));
    }

    // Because we are using doubles (floating point values), the values may not exactly match.
    // If the difference between the expected result, and the calculated result is less than .000001,
    // consider the two values as "equal".
    private bool ResultsAreCloseEnough(double expectedResult, double calculatedResult)
    {
        var difference = Math.Abs(expectedResult - calculatedResult);

        return difference < .000001;
    }
}
using System.Numerics;
using Algorithms.Arithmetic;
using FluentAssertions;

namespace Algorithms.Tests.Arithmetic;

public class GreatestCommonDivisorTests
{
    [Theory]
    [InlineData(100, 100)]
    [InlineData(10, 5)]
    [InlineData(7, 11)]
    [InlineData(-7, -11)]
    [InlineData(-7, 11)]
    [InlineData(-11, 7)]
    [InlineData(100000000000000, 2304120938120938120)]
    public void CorrectDivisorCalculated(long number1, long number2)
    {
        GreatestCommonDivisor.Calculate(number1, number2).Should().Be((long)BigInteger.GreatestCommonDivisor(number1, number2));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(0, 1)]
    public void ThrowsIfEitherZero(int number1, int number2)
    {
        var action = () => GreatestCommonDivisor.Calculate(number1, number2);

        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
}
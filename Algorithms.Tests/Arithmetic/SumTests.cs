using Algorithms.Arithmetic;
using FluentAssertions;

namespace Algorithms.Tests.Arithmetic;

public class SumTests
{
    public static List<object?[]> Integers =>
    [
        [new [] { 1, 8, 100, 88, -5, 20 }],
        [new [] { 0 }],
        [new [] { 1000000 }],
        [new [] { -1, 0, 1 }],
        [new [] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }],
        [new [] { 50, 60, 70, 80 }],
        [Array.Empty<int>()]
    ];
    
    public static List<object?[]> Doubles =>
    [
        [new[] { 1.0, 8.0, 100.0, 88.0, -5.0, 20.0 }],
        [new[] { 0.0 }],
        [new[] { 1000000.0 }],
        [new[] { 0.1 }],
        [new[] { 0.3, 0.5, 50.0, -1.0, -10.0, 8000000.0 }],
        [new[] { -1.0, 0.0, 1.0 }],
        [new[] { 10.0, 9.0, 8.0, 7.0, 6.0, 5.0, 4.0, 3.0, 2.0, 1.0 }],
        [new[] { 50.0, 60.0, 70.0, 80.0 }],
        [Array.Empty<double>()]
    ];
    
    public static List<object?[]> Decimals =>
    [
        [new [] { 1m, 8m, 100m, 88m, -5m, 20m }],
        [new [] { 0m }],
        [new [] { 1000000m }],
        [new [] { 0.1m }],
        [new [] { 0.3m, 0.5m, 50.0m, -1.0m, -10.0m, 8000000.0m }],
        [new [] { -1m, 0m, 1m }],
        [new [] { 10m, 9m, 8m, 7m, 6m, 5m, 4m, 3m, 2m, 1m }],
        [new [] { 50m, 60m, 70m, 80m }],
        [Array.Empty<decimal>()]
    ];
    
    [Theory]
    [MemberData(nameof(Integers))]
    public void SumSumsInt(int[] numbers)
    {
        numbers.SumRecursive().Should().Be(numbers.Sum());
    }
    
    [Theory]
    [MemberData(nameof(Doubles))]
    public void SumSumsDoubles(double[] numbers)
    {
        numbers.SumRecursive().Should().Be(numbers.Sum());
    }
    
    [Theory]
    [MemberData(nameof(Decimals))]
    public void SumSumsDecimals(decimal[] numbers)
    {
        numbers.SumRecursive().Should().Be(numbers.Sum());
    }
}
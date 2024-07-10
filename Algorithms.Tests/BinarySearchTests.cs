using Algorithms.BinarySearch;
using FluentAssertions;

namespace Algorithms.Tests;

public class BinarySearchTests
{
    public static IEnumerable<object?[]> SuccessCases =>
        new List<object?[]>
        {
            new object[] { new List<IComparable> { 1, 2, 3, 4, 5 }.Order(), 3, false, 2 },
            new object?[] { new List<IComparable> { 1, 2, 3, 4, 5 }.Order(), 10, false, -1 },
            new object?[] { new List<IComparable> { 5, 4, 3, 2, 1 }.OrderDescending(), 1, true, 4 },
            new object?[] { new List<IComparable> { 1000000000 }.Order(), 1000000000, false, 0 },
            new object?[] { new List<IComparable> { 1000000000 }.Order(), 1, false, -1 },
            new object?[] { new List<IComparable>().OrderDescending(), 1, true, -1 },
            new object?[] { new List<IComparable>().Order(), 1, true, -1 },
            new object?[] { new List<IComparable> { -1, 0, 1 }.Order(), -1, false, 0 },
            new object?[] { new List<IComparable> { 0.001, 0.002, 0.003 }.Order(), 0.003, false, 2 },
        };

    [Theory]
    [MemberData(nameof(SuccessCases))]
    public void CorrectIndexReturned(IOrderedEnumerable<IComparable> items, IComparable target, bool isDescending, int expectedIndex)
    {
        var result = items.BinarySearch(target, isDescending);

        result.Should().Be(expectedIndex);
    }
}
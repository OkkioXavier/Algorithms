using Algorithms.Sorting;
using FluentAssertions;

namespace Algorithms.Tests.Sorting;

public class SelectionSortTests
{
    public static List<object?[]> Collections =>
    [
        [new List<IComparable> { 1, 8, 100, 88, -5, 20 }],
        [new List<IComparable> { 0 }],
        [new List<IComparable> { 1000000 }],
        [new List<IComparable> { 0.1 }],
        [new List<IComparable> { 0.3, 0.5, 50.0, -1.0, -10.0, 8000000.0 }],
        [new List<IComparable> { -1, 0, 1 }],
        [new List<IComparable> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }],
        [new List<IComparable> { 50, 60, 70, 80 }],
        [new List<IComparable> { 8289, 8289, 8289, 8289, 8289, 8289 }],
        [new List<IComparable>()]
    ];

    [Theory]
    [MemberData(nameof(Collections))]
    public void CollectionsAreSorted(List<IComparable> items)
    {
        var sortedItems = items.Order().ToList();
        items.SelectionSort();

        items.Should().BeEquivalentTo(sortedItems);
    }
}
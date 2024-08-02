using Algorithms.Sorting;
using FluentAssertions;

namespace Algorithms.Tests.Sorting;

public class SelectionSortTests : SortingTest
{
    [Theory]
    [MemberData(nameof(Collections))]
    public void CollectionsAreSorted(IList<IComparable> items)
    {
        var sortedItems = items.Order().ToList();
        items.SelectionSort();

        items.Should().BeEquivalentTo(sortedItems, o => o.WithStrictOrdering());
    }
}
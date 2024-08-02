using Algorithms.Sorting;
using FluentAssertions;

namespace Algorithms.Tests.Sorting;

public class QuickSortTests : SortingTest
{
    [Theory]
    [MemberData(nameof(Collections))]
    public void CollectionsAreSorted(IList<IComparable> items)
    {
        var sortedItems = items.Order().ToList();
        items.QuickSort();

        items
            .Should()
            .BeEquivalentTo(
                sortedItems,
                options => options.Using<IComparable>(c => c.Subject.Should().Be(c.Expectation))
                    .WhenTypeIs<IComparable>()
                    .WithStrictOrdering());
    }
}
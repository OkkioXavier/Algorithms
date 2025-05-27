using Algorithms.Sorting;
using FluentAssertions;

namespace Algorithms.Tests.Sorting;

public class MergeSortTests : SortingTest
{
    [Theory]
    [MemberData(nameof(Collections))]
    public void CollectionsAreSorted(IList<IComparable> items)
    {
        var array = items.ToArray();
        var sortedItems = items.Order().ToArray();
        var sorted = array.MergeSort();

        sorted
            .Should()
            .BeEquivalentTo(
                sortedItems,
                options => options.Using<IComparable>(c => c.Subject.Should().Be(c.Expectation))
                    .WhenTypeIs<IComparable>()
                    .WithStrictOrdering());
    }
}
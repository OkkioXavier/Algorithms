using Algorithms.Arrays;
using FluentAssertions;

namespace Algorithms.Tests.Arrays;

public class ArrayExtensionsTests
{
    [Fact]
    public void ArraysAreReversed()
    {
        int[] items = [1, 2, 3, 4];
        ArrayExtensions.ReverseInPlace<int>(items);

        items.Should().BeEquivalentTo([4, 3, 2, 1], o => o.WithStrictOrdering());
    }

    [Fact]
    public void ArraysAreRotatedRight()
    {
        int[] items = [1, 2, 3, 4, 5, 6, 7];

        items.AsSpan().RotateRight(3);

        items.Should().BeEquivalentTo([5, 6, 7, 1, 2, 3, 4], o => o.WithStrictOrdering());
    }

    [Fact]
    public void ArraysAreRotatedLeft()
    {
        int[] items = [1, 2, 3, 4, 5, 6, 7];

        items.AsSpan().RotateLeft(3);

        items.Should().BeEquivalentTo([4, 5, 6, 7, 1, 2, 3], o => o.WithStrictOrdering());
    }
}
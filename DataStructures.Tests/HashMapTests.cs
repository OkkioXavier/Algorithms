using FluentAssertions;

namespace DataStructures.Tests;

public class HashMapTests
{
    [Fact]
    public void ItemsCanBeAddedAndRetrieved()
    {
        var hashMap = new HashMap<int, int>();

        hashMap.Add(1, 2);

        hashMap[1].Should().Be(2);
    }
    
    [Fact]
    public void AddingTheSameKeyTwiceIsNotAllowed()
    {
        var hashMap = new HashMap<int, int>();

        hashMap.Add(1, 2);

        hashMap[1].Should().Be(2);
        
        var action = () => hashMap.Add(1, 3);

        action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void ContainsReturnsTrueForExistingKey()
    {
        var hashMap = new HashMap<int, int>([1], value => value);

        hashMap.Contains(1).Should().BeTrue();
    }
    
    [Fact]
    public void ContainsReturnsFalseForAbsentKey()
    {
        var hashMap = new HashMap<int, int>([1], value => value);

        hashMap.Contains(2).Should().BeFalse();
    }

    [Fact]
    public void ItemsCanAddedWithIndexer()
    {
        var hashMap = new HashMap<int, int>();

        hashMap[1] = 2;

        hashMap[1].Should().Be(2);
    }
    
    [Fact]
    public void ItemsCanBeSetWithIndexer()
    {
        var hashMap = new HashMap<int, int>([1], value => value);

        hashMap[1] = 2;

        hashMap[1].Should().Be(2);
    }

    [Fact]
    public void ValuesCanBeNull()
    {
        var hashMap = new HashMap<int, object?>();

        hashMap[1] = null;

        hashMap[1].Should().BeNull();
    }

    [Fact]
    public void CapacityRaisedAutomaticallyAt75PercentThreshold()
    {
        var hashMap = new HashMap<int, int>();

        hashMap.Capacity.Should().Be(16);

        for (var i = 0; i < 12; i++)
        {
            hashMap[i] = i;
        }

        hashMap.Capacity.Should().Be(32);
    }

    [Fact]
    public void IndexesAreStableAfterReallocation()
    {
        var hashMap = new HashMap<int, int>();

        hashMap.Capacity.Should().Be(16);

        for (var i = 0; i < 12; i++)
        {
            hashMap[i] = i;
        }

        hashMap.Capacity.Should().Be(32);

        for (var i = 0; i < 12; i++)
        {
            hashMap[i].Should().Be(i);
        }
    }

    [Fact]
    public void MoreItemsCanBeAddedThanAllowedByTheInitialCapacity()
    {
        var hashMap = new HashMap<int, int>();

        hashMap.Capacity.Should().Be(16);

        var action = () =>
        {
            for (var i = 0; i < 32; i++)
            {
                hashMap[i] = i;
            }
        };

        action.Should().NotThrow();
        
        for (var i = 0; i < 32; i++)
        {
            hashMap[i].Should().Be(i);
        }
    }

    [Fact]
    public void ItemsCanBeRemovedFromHashMap()
    {
        var hashMap = new HashMap<int, int>();
        hashMap[1] = 2;
        hashMap.Remove(1).Should().Be(2);

        var action = () => hashMap[1];

        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CanBeInitializedFromACollection()
    {
        var hashMap = new HashMap<int, int>(new[] { 1, 2, 3, 4, 5 }, value => value);

        hashMap[1].Should().Be(1);
        hashMap[2].Should().Be(2);
        hashMap[3].Should().Be(3);
        hashMap[4].Should().Be(4);
        hashMap[5].Should().Be(5);
    }

    [Fact]
    public void ReducingCapacityNotAllowed()
    {
        var hashMap = new HashMap<int, int>();

        var action = () => hashMap.Capacity = 15;

        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CapacityFloorIs16()
    {
        var hashMap = new HashMap<int, int>(new[] { 1, 2, 3, 4, 5 }, value => value);
        hashMap.Capacity.Should().Be(16);
    }
}
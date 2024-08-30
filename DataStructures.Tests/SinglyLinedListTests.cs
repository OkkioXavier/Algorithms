using DataStructures.Lists;
using FluentAssertions;

namespace DataStructures.Tests;

public class SinglyLinedListTests
{
    [Fact]
    public void ItemsCanBeAdded()
    {
        var list = BuildList();

        var next = list.Head;
        var expected = 0;
        var count = 0;

        while (next is not null)
        {
            next.Data.Should().Be(expected);
            count++;
            expected++;
            next = next.Next;
        }

        count.Should().Be(100);
    }

    [Fact]
    public void CanBeReversed()
    {
        var list = BuildList();

        list.Reverse();

        var node = list.Head;
        var expected = 99;
        var count = 0;

        while (node is not null)
        {
            node.Data.Should().Be(expected);
            count++;
            expected--;
            node = node.Next;
        }

        count.Should().Be(100);
    }

    private static SinglyLinkedList<int> BuildList()
    {
        var node = new SinglyLinkedListNode<int>(0);
        var current = node;

        for (var i = 1; i < 100; i++)
        {
            current.Next = new SinglyLinkedListNode<int>(i);
            current = current.Next;
        }

        var list = new SinglyLinkedList<int>(node);
        return list;
    }
}
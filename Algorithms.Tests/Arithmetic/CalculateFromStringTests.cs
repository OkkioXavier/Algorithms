using System.Text;
using Algorithms.Arithmetic;
using DataStructures.Graphs;
using DataStructures.Lists;
using FluentAssertions;

namespace Algorithms.Tests.Arithmetic;

public class CalculateFromStringTests
{
    [Theory]
    // Single Numbers
    [InlineData("1", 1)]
    [InlineData("1234", 1234)]
    // Addition
    [InlineData("1+1+1", 3)]
    [InlineData("1 + 1", 2)]
    [InlineData("1234 + 1", 1235)]
    //Subtraction
    [InlineData("1-1", 0)]
    [InlineData("1-1-1", -1)]
    // Unary Minus
    [InlineData("-1", -1)]
    // Multiply
    [InlineData("1 * 1", 1)]
    [InlineData("2 * 2 * 2", 8)]
    //Brackets
    [InlineData("()", 0)]
    [InlineData("(())", 0)]
    [InlineData("(()) + (())", 0)]
    [InlineData("(0)", 0)]
    [InlineData("((1))", 1)]
    [InlineData("(1) + (1)", 2)]
    [InlineData("(1) + (1) + (1)", 3)]
    [InlineData("(((1))+((1)))", 2)]
    // Mixed Operations
    [InlineData("1 - 1 + 1", 1)]
    [InlineData("-(1 + 1)", -2)]
    [InlineData("-1 - 1", -2)]
    [InlineData("2 * 2 + 1", 5)]
    [InlineData("1-(     -2)", 3)]
    [InlineData("(1+(4+5+2)-3)+(6+8)", 23)]
    public void CalculationCorrect(string calculation, int expectation)
    {
        CalculateFromString.Calculate(calculation).Should().Be(expectation);
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    static ListNode? BuildList(int [] nodes)
    {
        if (nodes.Length == 0)
        {
            return null;
        }

        var head = new ListNode(nodes[0]);
        var current = head;
        
        for (var i = 1; i < nodes.Length; i++)
        {
            current.next = new ListNode(nodes[i]);
            current = current.next;
        }

        return head;
    }

    [Fact]
    public void Partition()
    {
        int x = 3;
        var head = BuildList([1,4,3,2,5,2]);

        if (head.next is null)
        {
            return;
        }

        var partition = head;
        var dummy = new ListNode(-201);
        var prev = dummy; // This item is below the range so will ALWAYS come first
        prev.next = head;

        while (partition.val != x)
        {
            prev = partition;
            partition = partition.next;
        }

        // Cut the partition node out of the lift;
        var next = partition.next;
        // Stitch the lift back together
        prev.next = next;
        partition.next = null;

        var current = dummy.next; // dummy.next will never be the partition element because we cut it out
        var left = dummy; // We know dummy is ALREADY sorted
        left.next = partition;
        var right = partition;

        while (current is not null)
        {
            var temp = current.next;
            current.next = null;

            if (current.val < x)
            {
                left.next = current;
                current.next = partition;
                left = current;
            }
            else
            {
                right.next = current;
                right = current;
            }

            current = temp;
        }
    }
}
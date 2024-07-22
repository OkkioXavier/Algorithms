using Algorithms.Graphs;
using DataStructures.Graphs;
using FluentAssertions;

namespace Algorithms.Tests.Graphs.NodeExtensionTests;

public class BreadthFirstSearchTests
{
    [Fact]
    public void BreadthFirstSearchFindsNearestNeighbour()
    {
        var neighbour1 = new SimpleNode<int>(2, [new SimpleNode<int>(2, [])]);
        var node = new SimpleNode<int>(1, [neighbour1]);

        var result = node.BreadthFirstSearch(2);

        result.Should().BeSameAs(neighbour1);
    }
    
    [Fact]
    public void BreadthFirstSearchDoesntFollowCycles()
    {
        var neighbour1 = new SimpleNode<int>(2, []);
        var node = new SimpleNode<int>(1, [neighbour1]);
        neighbour1.AddNeighbour(node);

        var result = node.BreadthFirstSearch(6);

        result.Should().BeNull();
    }

    [Fact]
    public void BreadthFirstReturnsNullWhenNoNodeExists()
    {
        var neighbour1 = new SimpleNode<int>(2, [new SimpleNode<int>(2, [])]);
        var node = new SimpleNode<int>(1, [neighbour1]);

        var result = node.BreadthFirstSearch(3);

        result.Should().BeNull();
    }

    [Fact]
    public void BreadthFirstSearchCanFindNodesBelowFirstLevel()
    {
        var deepNode = new SimpleNode<int>(3, []);
        var node = new SimpleNode<int>(1, [new SimpleNode<int>(2, [new SimpleNode<int>(2, [deepNode])])]);

        var result = node.BreadthFirstSearch(3);

        result.Should().BeSameAs(deepNode);
    }

    [Fact]
    public void FindShortestPathFindsShortestPath()
    {
        var node4 = new SimpleNode<int>(4, []);
        var node = new SimpleNode<int>(1,
            [
                new SimpleNode<int>(2, [node4]),
                new SimpleNode<int>(
                    3,
                    [
                        new SimpleNode<int>(5, [node4])
                    ])
            ]);
        var path = node.FindShortestPathTo(4);

        path![0].Should().Be(node);
        path[1].Value.Should().Be(2);
        path[2].Value.Should().Be(4);
    }
    
    [Fact]
    public void FindShortestPathReturnsNullIfNoPathExists()
    {
        var node4 = new SimpleNode<int>(4, []);
        var node = new SimpleNode<int>(1,
        [
            new SimpleNode<int>(2, [node4]),
            new SimpleNode<int>(
                3,
                [
                    new SimpleNode<int>(5, [node4])
                ])
        ]);
        var path = node.FindShortestPathTo(6);

        path.Should().BeNull();
    }
    
    [Fact]
    public void FindShortestPathDoesntFollowCycles()
    {
        var neighbour1 = new SimpleNode<int>(2, []);
        var node = new SimpleNode<int>(1, [neighbour1]);
        neighbour1.AddNeighbour(node);

        var result = node.FindShortestPathTo(6);

        result.Should().BeNull();
    }
}
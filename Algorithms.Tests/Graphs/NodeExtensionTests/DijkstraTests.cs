using Algorithms.Graphs;
using DataStructures.Graphs;
using FluentAssertions;

namespace Algorithms.Tests.Graphs.NodeExtensionTests;

public class DijkstraTests
{
    public static IEnumerable<object[]> TestGraphs()
    {
        var node4 = new NodeWithWeightedNeighbours<int>(4, []);
        var node3 = new NodeWithWeightedNeighbours<int>(3, [new WeightedNeighbour<int>(node4, 10)]);
        var node2 = new NodeWithWeightedNeighbours<int>(2, [new WeightedNeighbour<int>(node3, 10)]);
        var node1 = new NodeWithWeightedNeighbours<int>(1, [new WeightedNeighbour<int>(node2, 80), new WeightedNeighbour<int>(node4, 1000)]);
        var path = new LinkedList<NodeWithWeightedNeighbours<int>>();
        path.AddFirst(node1);
        path.AddFirst(node2);
        path.AddFirst(node3);
        path.AddFirst(node4);
        yield return [node1, path, 100];


        var node5 = new NodeWithWeightedNeighbours<int>(1, []);
        
        yield return [node5, new LinkedList<NodeWithWeightedNeighbours<int>>(), double.PositiveInfinity];
    }
    
    [Theory]
    [MemberData(nameof(TestGraphs))]
    public void DijkstraFindLowestWeightPathToNode(NodeWithWeightedNeighbours<int> entryNode, LinkedList<NodeWithWeightedNeighbours<int>> expectedPath, double expectedDistance)
    {

        var (path, distance) = entryNode.Dijkstra(4);

        distance.Should().Be(expectedDistance);
        path.Should().BeEquivalentTo(expectedPath);
    }
}
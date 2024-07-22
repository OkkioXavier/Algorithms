using DataStructures;
using DataStructures.Graphs;

namespace Algorithms.Graphs;

public static class NodeExtensions
{
    /// <summary>
    /// Finds the nearest node with the value
    /// </summary>
    /// <returns>A node with the value or null</returns>
    public static Node<TValue>? BreadthFirstSearch<TValue>(this Node<TValue> sourceNode, TValue value)
    {
        var nodes = new Queue<Node<TValue>>([sourceNode]);
        var visited = new HashSet<Node<TValue>>();

        while (nodes.Count > 0)
        {
            var node = nodes.Dequeue();

            if (EqualityComparer<TValue>.Default.Equals(node.Value, value))
            {
                return node;
            }

            visited.Add(node);

            foreach (var neighbour in node.Neighbours)
            {
                if (!visited.Contains(neighbour.Node))
                {
                    nodes.Enqueue(neighbour.Node);
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Finds the shortest path from the given node to a node containing the value
    /// </summary>
    /// <returns>An array of nodes defining the path</returns>
    public static List<Node<TValue>>? FindShortestPathTo<TValue>(this Node<TValue> sourceNode, TValue value)
    {
        var nodes = new Queue<LinkedNode<TValue>>([new LinkedNode<TValue>(sourceNode, null)]);
        var visited = new HashSet<Node<TValue>>();

        do
        {
            var linkedNode = nodes.Dequeue();

            if (EqualityComparer<TValue>.Default.Equals(linkedNode.Node.Value, value))
            {
                var path = new List<Node<TValue>>([linkedNode.Node]);
                var parent = linkedNode.Parent;

                while (parent is not null)
                {
                    path.Insert(0, parent.Node);
                    parent = parent.Parent;
                }

                return path;
            }

            visited.Add(linkedNode.Node);

            foreach (var neighbour in linkedNode.Node.Neighbours)
            {
                if (!visited.Contains(neighbour.Node))
                {
                    nodes.Enqueue(new LinkedNode<TValue>(neighbour.Node, linkedNode));
                }
            }
        } while (nodes.Count > 0);

        return null;
    }
    
    public static (IEnumerable<NodeWithWeightedNeighbours<TValue>> path, double distance) Dijkstra<TValue>(this NodeWithWeightedNeighbours<TValue> entryNode, TValue end)
        where TValue : notnull
    {
        var queue = new PriorityQueue<NodeWithWeightedNeighbours<TValue>, double>([(entryNode, 0)]);
        var map = new HashMap<TValue, (double Distance, NodeWithWeightedNeighbours<TValue>? Parent)> { { entryNode.Value, (0, null)}, {end, (double.PositiveInfinity, null) } };
        NodeWithWeightedNeighbours<TValue>? endNode = null;

        while (queue.TryDequeue(out var node, out var distance))
        {
            endNode ??= EqualityComparer<TValue>.Default.Equals(node.Value, end) ? node : null; 
            
            foreach (var neighbour in node.WeightedNeighbours)
            {
                var nodeValue = neighbour.Node.Value;
                var newDistance = distance + neighbour.Weight;
                if (map.Contains(nodeValue))
                {
                    if (map[nodeValue].Distance > newDistance)
                    {
                        map[nodeValue] = (newDistance, node);
                    }
                }
                else
                {
                    map.Add(nodeValue, (distance + neighbour.Weight, node));
                }

                queue.Enqueue(neighbour.WeightedNode, map[nodeValue].Distance);
            }
        }

        if (endNode is null)
        {
            return ([], double.PositiveInfinity);
        }
        
        var pathNode = map[end].Parent;
        var path = new LinkedList<NodeWithWeightedNeighbours<TValue>>();
        path.AddFirst(endNode);

        while (pathNode is not null)
        {
            path.AddFirst(pathNode);
            pathNode = map[pathNode.Value].Parent;
        }

        return (path, map[end].Distance);
    }

    private record LinkedNode<TValue>(Node<TValue> Node, LinkedNode<TValue>? Parent);
}
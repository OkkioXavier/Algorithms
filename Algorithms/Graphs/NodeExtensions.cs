using DataStructures;

namespace Algorithms.Graphs;

public static class NodeExtensions
{
    /// <summary>
    /// Finds the nearest node with the value
    /// </summary>
    /// <returns>A node with the value or null</returns>
    public static Node<T>? BreadthFirstSearch<T>(this Node<T> sourceNode, T value)
    {
        var nodes = new Queue<Node<T>>([sourceNode]);
        var visited = new HashSet<Node<T>>();

        while (nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            
            if (EqualityComparer<T>.Default.Equals(node.Value, value))
            {
                return node;
            }

            visited.Add(node);

            foreach (var neighbour in node.Neighbours)
            {
                if (!visited.Contains(neighbour))
                {
                    nodes.Enqueue(neighbour);
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Finds the shortest path from the given node to a node containing the value
    /// </summary>
    /// <returns>An array of nodes defining the path</returns>
    public static List<Node<T>>? FindShortestPathTo<T>(this Node<T> sourceNode, T value)
    {
        var nodes = new Queue<LinkedNode<T>>([new LinkedNode<T>(sourceNode, null)]);
        var visited = new HashSet<Node<T>>();

        do
        {
            var linkedNode = nodes.Dequeue();

            if (EqualityComparer<T>.Default.Equals(linkedNode.Node.Value, value))
            {
                var path = new List<Node<T>>([linkedNode.Node]);
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
                if (!visited.Contains(neighbour))
                {
                    nodes.Enqueue(new LinkedNode<T>(neighbour, linkedNode));
                }
            }

        } while (nodes.Count > 0);

        return null;
    }

    private record LinkedNode<T> (Node<T> Node, LinkedNode<T>? Parent);
}
namespace DataStructures.Graphs;

public record Graph<TNode, TValue, TNeighbour> 
    where TNode: Node<TValue>
    where TValue : notnull
    where TNeighbour: Neighbour<TValue>
{
    public Dictionary<TValue, TNode> Nodes { get; private set; }
    
    public Graph(List<TNode> nodes)
    {
        Nodes = nodes.ToDictionary(n => n.Value);
    }
}
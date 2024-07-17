namespace DataStructures;

public record Graph<T> where T : notnull
{
    public Dictionary<T, Node<T>> Nodes { get; private set; }
    
    public Graph(List<Node<T>> nodes)
    {
        Nodes = nodes.ToDictionary(n => n.Value);
    }
}
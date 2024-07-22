namespace DataStructures.Graphs;

public record Neighbour<TValue>(Node<TValue> Node)
{
    public static implicit operator Neighbour<TValue>(Node<TValue> node) => new(node);
}
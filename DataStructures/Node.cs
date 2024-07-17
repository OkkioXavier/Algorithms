namespace DataStructures;

public record Node<T>(T Value, List<Node<T>> Neighbours);

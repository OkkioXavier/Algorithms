namespace DataStructures.Graphs;

public abstract record Node<TValue>(TValue Value)
{
    public abstract IReadOnlyCollection<Neighbour<TValue>> Neighbours { get; }
};

namespace DataStructures.Graphs;

public record SimpleNode<TValue> : Node<TValue>
{
    private readonly List<Neighbour<TValue>> _neighbours;

    public override IReadOnlyCollection<Neighbour<TValue>> Neighbours => _neighbours;

    public SimpleNode(TValue value, List<Neighbour<TValue>> neighbours) : base(value)
    {
        _neighbours = neighbours;
    }

    public void AddNeighbour(Neighbour<TValue> weightedNeighbour)
    {
        if (!Neighbours.Contains(weightedNeighbour))
        {
            _neighbours.Add(weightedNeighbour);
        }
    }

    public void RemoveNeighbour(Neighbour<TValue> weightedNeighbour)
    {
        _neighbours.Remove(weightedNeighbour);
    }
}
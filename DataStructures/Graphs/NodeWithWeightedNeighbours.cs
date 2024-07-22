namespace DataStructures.Graphs;

public record NodeWithWeightedNeighbours<TValue> : Node<TValue>
{
    private readonly List<WeightedNeighbour<TValue>> _weightedNeighbours;
    public IReadOnlyCollection<WeightedNeighbour<TValue>> WeightedNeighbours => _weightedNeighbours;
    public override IReadOnlyCollection<Neighbour<TValue>> Neighbours => _weightedNeighbours;

    public NodeWithWeightedNeighbours(TValue value, List<WeightedNeighbour<TValue>> weightedNeighbours) : base(value)
    {
        _weightedNeighbours = weightedNeighbours;
    }

    public void AddNeighbour(WeightedNeighbour<TValue> weightedNeighbour)
    {
        if (!WeightedNeighbours.Contains(weightedNeighbour))
        {
            _weightedNeighbours.Add(weightedNeighbour);
        }
    }

    public void RemoveNeighbour(WeightedNeighbour<TValue> weightedNeighbour)
    {
        _weightedNeighbours.Remove(weightedNeighbour);
    }
}
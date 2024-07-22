namespace DataStructures.Graphs;

public record WeightedNeighbour<TValue>(NodeWithWeightedNeighbours<TValue> WeightedNode, ulong Weight) : Neighbour<TValue>(WeightedNode);
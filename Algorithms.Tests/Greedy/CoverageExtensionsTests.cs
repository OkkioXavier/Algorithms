using Algorithms.Greedy;
using FluentAssertions;

namespace Algorithms.Tests.Greedy;

public class CoverageExtensionsTests
{
    [Fact]
    public void CoversAllRegionsIfPossible()
    {
        var stations = new Station<string>[]
        {
            new(["A", "B"]),
            new(["C"]),
            new(["A", "B", "C"]),
            new(["D"]),
            new(["E"]),
        };
        var (coveringStations, coveredRegions) = stations.FindCoverage("A", "B", "C", "E");


        coveringStations.Should().BeEquivalentTo([stations[2], stations[4]]);
        coveredRegions.Should().BeEquivalentTo(["A", "B", "C", "E"], o => o.WithStrictOrdering());
    }

    [Fact]
    public void ReturnsEmptyEnumerablesIfStationsCannotCover()
    {
        var stations = new Station<string>[]
        {
            new(["A", "B", "C"]),
        };
        var (coveringStations, coveredRegions) = stations.FindCoverage("D", "E", "F");

        coveringStations.Should().BeEmpty();
        coveredRegions.Should().BeEmpty();
    }

    [Fact]
    public void ReturnsPartialCoverageIfFullCoverageImpossible()
    {
        var stations = new Station<string>[]
        {
            new(["A", "B"]),
            new(["C"]),
            new(["A", "B", "C"]),
            new(["D"]),
            new(["E"]),
        };
        var (coveringStations, coveredRegions) = stations.FindCoverage("A", "D", "E", "F");

        coveringStations.Should().BeEquivalentTo([stations[2], stations[3], stations[4]], o => o.WithStrictOrdering());
        coveredRegions.Should().BeEquivalentTo(["A", "D", "E"], o => o.WithStrictOrdering());
    }
}
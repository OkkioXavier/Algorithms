using Algorithms.Greedy;
using BenchmarkDotNet.Attributes;
using Benchmarking.Common;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks.Greedy;

public class CoverageBenchmark(ITestOutputHelper output) : XunitBenchmark<CoverageBenchmark.CoverageBenchmarks>(output)
{
    public class CoverageBenchmarks
    {
        private static readonly int[] RegionsToCover = Enumerable.Range(0, 100).ToArray();
        private static readonly int[] StationRegions = Enumerable.Range(0, 500).ToArray();
        private static readonly Station<int>[] Stations = StationRegions.Select(r => new Station<int>([r])).ToArray();
        
        
        [Benchmark]
        public void FindCoverage()
        {
            Stations.FindCoverage(RegionsToCover);
        }
        
        [Benchmark]
        public void FindCoverageMinimalStations()
        {
            Stations.FindCoverageMinimalStations(RegionsToCover);
        }
    }
}
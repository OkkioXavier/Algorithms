using BenchmarkDotNet.Attributes;
using Benchmarking.Common;
using Xunit.Abstractions;

namespace DataStructures.Benchmarks;

public class HashMapBenchmark(ITestOutputHelper output) : XunitBenchmark<HashMapBenchmark.HashmapBenchmarks>(output)
{
    public class HashmapBenchmarks
    {
        [Benchmark]
        public void Construct()
        {
            _ = new HashMap<int, int>();
        }
        
        [Benchmark]
        public void Add()
        {
            new HashMap<int, int>().Add(1, 1);
        }
    }
}
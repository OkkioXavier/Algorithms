using Algorithms.Searching;
using BenchmarkDotNet.Attributes;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks.Searching;

public class BinarySearchBenchmark(ITestOutputHelper output) : XunitBenchmark<BinarySearchBenchmark.BinarySearchBenchmarks>(output)
{
    public class BinarySearchBenchmarks
    {
        private readonly List<int> _sampleList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

        [Benchmark]
        public void Search()
        {
            _sampleList.Order().BinarySearch(12);
        }
    }
}
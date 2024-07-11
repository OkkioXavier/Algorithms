using Algorithms.Sorting;
using BenchmarkDotNet.Attributes;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks.Sorting;

public class SelectionSortBenchmark(ITestOutputHelper output) : XunitBenchmark<SelectionSortBenchmark.SelectionSortBenchmarks>(output)
{
    public class SelectionSortBenchmarks
    {
        private readonly List<int> _sampleList = [10, 8, 1000, 1, 50, -10, 80, 6, 5, 817, 8390, -191];

        [Benchmark]
        public void Sort()
        {
            _sampleList.SelectionSort();
        }
    }
}
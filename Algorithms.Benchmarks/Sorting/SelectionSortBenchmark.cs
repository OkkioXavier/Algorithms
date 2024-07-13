using Algorithms.Sorting;
using BenchmarkDotNet.Attributes;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks.Sorting;

public class SelectionSortBenchmark(ITestOutputHelper output) : XunitBenchmark<SelectionSortBenchmark.SelectionSortBenchmarks>(output)
{
    public class SelectionSortBenchmarks
    {
        [Benchmark]
        public void Sort()
        {
            SortingData.SampleList.SelectionSort();
        }
    }
}
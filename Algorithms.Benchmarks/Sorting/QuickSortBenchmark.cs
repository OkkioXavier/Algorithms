using Algorithms.Sorting;
using BenchmarkDotNet.Attributes;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks.Sorting;

public class QuickSortBenchmark(ITestOutputHelper output) : XunitBenchmark<QuickSortBenchmark.QuickSortBenchmarks>(output)
{
    public class QuickSortBenchmarks
    {
        [Benchmark]
        public void Sort()
        {
            SortingData.SampleList.QuickSort();
        }
    }
}
using Algorithms.Arithmetic;
using BenchmarkDotNet.Attributes;
using Benchmarking.Common;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks.Arithmetic;

public class GreatestCommonDivisorBenchmark(ITestOutputHelper output)
    : XunitBenchmark<GreatestCommonDivisorBenchmark.GreatestCommonDivisorBenchmarks>(output)
{
    public class GreatestCommonDivisorBenchmarks
    {
        [Benchmark]
        public void Calculate()
        {
            GreatestCommonDivisor.Calculate(819171981271818195, 81111918195);
        }
    }
}
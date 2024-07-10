using Algorithms.BinarySearch;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks;

public class BinarySearchBenchmarkRunner
{
    private readonly ITestOutputHelper output;

    public BinarySearchBenchmarkRunner(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Fact]
    public void Benchmark()
    {
        var logger = new AccumulationLogger();

        var config = ManualConfig.Create(DefaultConfig.Instance)
            .AddLogger(logger)
            .WithOptions(ConfigOptions.DisableOptimizationsValidator);
        
        BenchmarkRunner.Run<BinarySearchBenchmarks>(config);
        
        output.WriteLine(logger.GetLog());
    }

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
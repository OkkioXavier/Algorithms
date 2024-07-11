using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks;

public abstract class XunitBenchmark<T> : IDisposable
{
    private readonly ITestOutputHelper _output;
    protected readonly ManualConfig Config;
    private readonly AccumulationLogger _logger;

    protected XunitBenchmark(ITestOutputHelper output)
    {
        _output = output;
        
        _logger = new AccumulationLogger();

        Config = ManualConfig.Create(DefaultConfig.Instance)
            .AddLogger(_logger)
            .WithOptions(ConfigOptions.DisableOptimizationsValidator);
    }
    
    
    [Fact]
    public void Benchmark()
    {
        BenchmarkRunner.Run<T>(Config);
    }

    public void Dispose()
    {
        _output.WriteLine(_logger.GetLog());
    }
}
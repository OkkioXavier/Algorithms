using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Diagnostics.dotTrace;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using Xunit;
using Xunit.Abstractions;

namespace Benchmarking.Common;

public abstract class XunitBenchmark<T> : IDisposable
{
    private readonly ITestOutputHelper _output;
    private readonly ManualConfig _config;
    private readonly AccumulationLogger _logger;

    protected XunitBenchmark(ITestOutputHelper output)
    {
        _output = output;
        
        _logger = new AccumulationLogger();

        _config = ManualConfig.Create(DefaultConfig.Instance)
            .AddDiagnoser(new DotTraceDiagnoser())
            .AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig()))
            .AddLogger(_logger)
            .WithOptions(ConfigOptions.DisableOptimizationsValidator);
    }
    
    
    [Fact]
    public void Benchmark()
    {
        BenchmarkRunner.Run<T>(_config);
    }

    public void Dispose()
    {
        _output.WriteLine(_logger.GetLog());
    }
}
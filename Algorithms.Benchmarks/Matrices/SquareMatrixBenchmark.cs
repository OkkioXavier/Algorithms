using Algorithms.Matrices;
using BenchmarkDotNet.Attributes;
using Benchmarking.Common;
using Xunit.Abstractions;

namespace Algorithms.Benchmarks.Matrices;

public class SquareMatrixBenchmark(ITestOutputHelper output) : XunitBenchmark<SquareMatrixBenchmark.SquareMatrixBenchmarks>(output)
{
    public class SquareMatrixBenchmarks
    {
        private static readonly int[,] Data =
        {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { 16, 17, 18, 19, 20 },
            { 21, 22, 23, 24, 25 },
        };

        private readonly SquareMatrix _matrix = new(Data);

        [Benchmark]
        public void Rotate()
        {
            _matrix.Rotate90();
        }

        [Benchmark]
        public void RotateInPlace()
        {
            _matrix.Rotate90InPlace();
        }
    }
}
using BenchmarkDotNet.Running;

namespace Nox.Types.Benchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<LanguageCodeBenchmarks>();
    }
}
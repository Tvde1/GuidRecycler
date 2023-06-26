using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;

using GuidRecycler.Strategies;

BenchmarkRunner.Run<Benchmark>();

[SimpleJob]
[MemoryDiagnoser(false)]
public class Benchmark
{
    private readonly ConcurrentGuidRecycler _concurrentGuidRecycler = new();
    private readonly GuidRecyclerSlim _guidRecyclerSlim = new();

    [Params(10, 1_000, 100_000)]
    public int RecyclerCapacity { get; set; } = 1000;

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (var i = 0; i < RecyclerCapacity; i++)
        {
            _concurrentGuidRecycler.Recycle(Guid.NewGuid());
            _guidRecyclerSlim.Recycle(Guid.NewGuid());
        }
    }

    [IterationSetup]
    public void IterationSetup()
    {
        _concurrentGuidRecycler.Recycle(Guid.NewGuid());
        _guidRecyclerSlim.Recycle(Guid.NewGuid());
    }

    [Benchmark(Baseline = true)]
    public Guid NewGuid()
    {
        return Guid.NewGuid();
    }

    [Benchmark]
    public Guid ConcurrentGuidRecycler()
    {
        return _concurrentGuidRecycler.GetGuid();
    }

    [Benchmark]
    public Guid GuidRecyclerSlim()
    {
        return _guidRecyclerSlim.GetGuid();
    }
}
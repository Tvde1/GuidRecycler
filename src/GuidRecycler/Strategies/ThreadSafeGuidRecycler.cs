using System.Collections.Concurrent;

using GuidRecycler.Interfaces;

namespace GuidRecycler.Strategies;

public class ConcurrentGuidRecycler : IGuidRecycler
{
    private readonly ConcurrentQueue<Guid> _queue = new();

    public void Recycle(Guid guid)
    {
        _queue.Enqueue(guid);
    }

    public Guid GetGuid()
    {
        return _queue.TryDequeue(out var guid) ? guid : Guid.NewGuid();
    }
}

public class GuidRecyclerSlim : IGuidRecycler
{
    private readonly Queue<Guid> _queue = new();

    public void Recycle(Guid guid)
    {
        _queue.Enqueue(guid);
    }

    public Guid GetGuid()
    {
        return _queue.TryDequeue(out var guid) ? guid : Guid.NewGuid();
    }
}
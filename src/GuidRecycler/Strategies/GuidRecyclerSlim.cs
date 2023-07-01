using GuidRecycler.Interfaces;

namespace GuidRecycler.Strategies;

/// <summary>
/// A non-thread-safe guid recycler implementation built
/// for high performance.
/// </summary>
public class GuidRecyclerSlim : IGuidRecycler
{
    private readonly Queue<Guid> _queue = new();

    /// <inheritdoc />
    public void Recycle(Guid guid)
    {
        _queue.Enqueue(guid);
    }

    /// <inheritdoc />
    public Guid GetGuid()
    {
        return _queue.TryDequeue(out var guid) ? guid : Guid.NewGuid();
    }
}
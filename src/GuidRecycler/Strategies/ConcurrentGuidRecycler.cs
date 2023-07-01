using System.Collections.Concurrent;
using GuidRecycler.Interfaces;

namespace GuidRecycler.Strategies;

/// <summary>
/// A thread-safe guid recycler implementation
/// </summary>
public class ConcurrentGuidRecycler : IGuidRecycler
{
    private readonly ConcurrentQueue<Guid> _queue = new();

    /// <summary>
    /// A thread safe way of recycling a
    /// guid to the recycle bin
    /// </summary>
    /// <param name="guid">The guid to recycle.</param>
    public void Recycle(Guid guid)
    {
        _queue.Enqueue(guid);
    }

    /// <summary>
    /// A thread safe way of receiving a recycled (or new) guid.
    /// </summary>
    /// <returns>The recycled or new guid</returns>
    public Guid GetGuid()
    {
        return _queue.TryDequeue(out var guid) ? guid : Guid.NewGuid();
    }
}
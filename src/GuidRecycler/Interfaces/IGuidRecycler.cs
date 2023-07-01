namespace GuidRecycler.Interfaces;

/// <summary>
/// The contract for a guid recycler.
/// </summary>
public interface IGuidRecycler
{
    /// <summary>
    /// Recycle a guid to the recycle bin..
    /// </summary>
    /// <param name="guid">The guid to recycle</param>
    void Recycle(Guid guid);

    /// <summary>
    /// Receive a guid from the recycle bin or
    /// create a new one if the bin is empty.
    /// </summary>
    /// <returns>A possibly-recycled guid</returns>
    Guid GetGuid();
}
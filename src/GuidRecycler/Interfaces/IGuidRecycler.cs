namespace GuidRecycler.Interfaces;

/// <summary>
/// A thead-safe class that recycles guids.
/// </summary>
public interface IGuidRecycler
{
    /// <summary>
    /// Thread safe method to recycle a guid.
    /// </summary>
    /// <param name="guid"></param>
    void Recycle(Guid guid);

    /// <summary>
    /// Thread safe method to recieve a guid from the recycle bin.
    /// </summary>
    /// <returns>A recycled guid</returns>
    Guid GetGuid();
}
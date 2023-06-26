using GuidRecycler.Strategies;

namespace GuidRecycler.Tests;

public class ConcurrentGuidRecyclerTests : BaseGuidRecyclerTests<ConcurrentGuidRecycler>
{
    public ConcurrentGuidRecyclerTests() : base(() => new ConcurrentGuidRecycler())
    {
    }
}
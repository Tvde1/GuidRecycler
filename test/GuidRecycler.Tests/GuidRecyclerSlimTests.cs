using GuidRecycler.Strategies;

namespace GuidRecycler.Tests;

public class GuidRecyclerSlimTests : BaseGuidRecyclerTests<GuidRecyclerSlim>
{
    public GuidRecyclerSlimTests() : base(() => new GuidRecyclerSlim())
    {
    }
}
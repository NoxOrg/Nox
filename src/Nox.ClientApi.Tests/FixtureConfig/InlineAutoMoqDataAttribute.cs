using AutoFixture.Xunit2;
using Nox.Lib.Tests.FixtureConfig;

namespace Nox.ClientApi.Tests.FixtureConfig;

public class InlineAutoMoqDataAttribute : CompositeDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] values)
        : base(new InlineDataAttribute(values), new AutoMoqDataAttribute())
    {
    }
}

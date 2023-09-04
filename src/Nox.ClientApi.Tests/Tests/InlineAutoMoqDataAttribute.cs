using AutoFixture.Xunit2;
using Nox.Lib.Tests.FixtureConfig;

namespace Nox.ClientApi.Tests;

public class InlineAutoMoqDataAttribute : CompositeDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] values)
        : base(new InlineDataAttribute(values), new AutoMoqDataAttribute())
    {
    }
}

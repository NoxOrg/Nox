using AutoFixture.Xunit2;

namespace Nox.Ui.Blazor.Lib.Tests.FixtureConfig;

public class InlineAutoMoqDataAttribute : CompositeDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] values)
        : base(new InlineDataAttribute(values), new AutoMoqDataAttribute())
    {
    }
}

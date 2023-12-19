using AutoFixture.Xunit2;

namespace No.Ui.Blazor.Lib.Tests.FixtureConfig;

public class InlineAutoMoqDataAttribute : CompositeDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] values)
        : base(new InlineDataAttribute(values), new AutoMoqDataAttribute())
    {
    }
}

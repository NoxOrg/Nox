using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoFixture;

namespace No.Ui.Blazor.Lib.Tests.FixtureConfig;

public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute()
        : base(CreateFixture)
    {
    }

    private static IFixture CreateFixture()
    {
        var fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization());
        return fixture;
    }
}

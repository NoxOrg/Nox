// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class NuidTests
{
    private const string TestStringValue = "!#123TestValue456!#";
    private const uint ExpectedNuidValue = 598674021;
    private const string ExpectedBase36 = "XTNFW9";
    private readonly Guid ExpectedGuid = new("00000000-0000-0000-0000-000023af0a65");

    [Fact]
    public void CreateNuiidFromString_CheckImplementation_ShouldNotBeChanged()
    {
        var nuidLeft = Nuid.From(TestStringValue);
        var nuidRight = Nuid.From(TestStringValue);

        nuidLeft.Should().Be(nuidRight);
        nuidLeft.Value.Should().Be(ExpectedNuidValue);
        nuidRight.Value.Should().Be(ExpectedNuidValue);
        nuidRight.Value.Should().Be(nuidRight.Value);

        nuidLeft.ToGuid().Should().Be(nuidRight.ToGuid());
        nuidLeft.ToGuid().Should().Be(ExpectedGuid);
        nuidLeft.ToHex().Should().Be(nuidRight.ToHex());

        nuidLeft.ToBase36().Should().Be(nuidRight.ToBase36());
        nuidLeft.ToBase36().Should().Be(ExpectedBase36);
    }
}
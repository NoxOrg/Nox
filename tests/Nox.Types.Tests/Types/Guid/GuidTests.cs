// ReSharper disable once CheckNamespace

using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class GuidTests
{
    [Fact]
    public void FromString_Construct_ReturnNewGuid()
    {
        var textGuid = System.Guid.NewGuid().ToString();

        var guid = Guid.From(textGuid);

        guid.Should().NotBeNull();
        guid.Value.Should().NotBeEmpty();
        guid.ToString().Should().Be(textGuid);
    }

    [Fact]
    public void Guid_Equals_SameGuid_ReturnTrue()
    {
        var systemGuid = System.Guid.NewGuid();

        var guid1 = Guid.From(systemGuid);
        var guid2 = Guid.From(systemGuid);

        guid1.Should().Be(guid2);
    }

    [Fact]
    public void Guid_NewGuid_ReturnsValidGuid()
    {
        var guid = Guid.NewGuid().ToString();

        System.Guid.TryParse(guid, out _).Should().BeTrue();
    }
}
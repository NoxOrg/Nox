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

    [Fact]
    public void Guid_From_ZeroedString_ThrowsException()
    {
        var emptyGuid = "00000000-0000-0000-0000-000000000000";

        var act = () => Guid.From(emptyGuid);

        act.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value",
                    "Could not create a Nox Guid type as empty Guid is not allowed.")
            });
    }

    [Fact]
    public void Guid_From_EmptyGuid_ThrowsException()
    {
        var act = () => Guid.From(System.Guid.Empty);

        act.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value",
                    "Could not create a Nox Guid type as empty Guid is not allowed.")
            });
    }
}
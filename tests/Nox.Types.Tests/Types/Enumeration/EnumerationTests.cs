using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class EnumerationTests
{

    private static readonly List<EnumerationValues> _values = new ()
        {
            new () { Id = 1, Name = "Option 1" },
            new () { Id = 2, Name = "Option 2" },
            new () { Id = 3, Name = "Option 3" },
        };

    private static readonly EnumerationTypeOptions _options = new ()
    {
        Values = _values,
        IsLocalized = true,
    };


    [Fact]
    public void Enum_Constructor_ReturnsDefaults()
    {
        var value = Enumeration.From(2, _options);

        // Assert 
        value.Value.Should().Be(2); 
    }

    [Fact]
    public void Enum_Constructor_ReturnsString()
    {
        var value = Enumeration.From(2, _options);

        // Assert 
        value.ToString().Should().Be("Option 2");
    }

    [Fact]
    public void Enum_Constructor_FromString_ReturnsEnumerator()
    {
        var value = Enumeration.From("Option 3", _options);

        // Assert 
        value.Value.Should().Be(3);
    }

    [Fact]
    public void Enum_Constructor_FromUpperCaseString_ReturnsEnumerator()
    {
        var value = Enumeration.From("OPTION 1", _options);

        // Assert 
        value.Value.Should().Be(1);
    }

    [Fact]
    public void Enum_Constructor_FromInvalidId_ThrowsError()
    {

        var action = () => Enumeration.From(42, _options);

        // Assert 
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(
            new[] { new ValidationFailure("Value", "No enumerator exists with an Id of '42'") });
    }

    [Fact]
    public void Enum_Constructor_FromInvalidDescription_ThrowsError()
    {
        var action = () => Enumeration.From("Option 42", _options);

        // Assert 
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(
            new[] { new ValidationFailure("Value", "No enumerator exists with an Description of 'Option 42'.") });

    }
}
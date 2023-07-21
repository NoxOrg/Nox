// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class PhoneNumberTests
{
    [Theory]
    [ClassData(typeof(PhoneNumberTestsDataClass))]
    public void PhoneNumber_Constructor_ReturnsSameValue(string value)
    {
        var phoneNumber = PhoneNumber.From(value);

        phoneNumber.Value.Should().Be(value);
    }

    [Theory]
    [InlineData("1-234-567-8901 x1234")]
    [InlineData("1-234-567-8901 ext1234")]
    [InlineData("1-234-567-8901 ext. 1234")]
    [InlineData("1.234.567.8901")]
    [InlineData("1/234/567/8901")]
    [InlineData("(+351) 282 433 5050")]
    [InlineData("123 456 7890 until 6pm, then 098 765 4321")]
    public void PhoneNumber_Constructor_WithInvalidInput_ThrowsValidationException(string value)
    {
        var action = () => PhoneNumber.From(value);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox PhoneNumber type with invalid value '{value}'.") });
    }
}
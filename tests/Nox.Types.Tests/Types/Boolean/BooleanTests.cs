using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class BooleanTests
{
    [Theory]
    [ClassData(typeof(BooleanTestData))]
    public void Boolean_Constructor_ReturnsExpectedValue(object testValue, bool expectedResult)
    {
        Boolean result;

        switch (testValue)
        {
            case bool boolValue:
                result = Boolean.From(boolValue);
                break;
            case byte byteValue:
                result = Boolean.From(byteValue);
                break;
            case short shortValue:
                result = Boolean.From(shortValue);
                break;
            case int intValue:
                result = Boolean.From(intValue);
                break;
            case long longValue:
                result = Boolean.From(longValue);
                break;
            case float floatValue:
                result = Boolean.From(floatValue);
                break;
            case double doubleValue:
                result = Boolean.From(doubleValue);
                break;
            case decimal decimalValue:
                result = Boolean.From(decimalValue);
                break;
            case string stringValue:
                result = Boolean.From(stringValue);
                break;
            default:
                throw new NotImplementedException();
        }

        result.Value.Should().Be(expectedResult);
    }

    [Fact]
    public void Boolean_Constructor_WithInvalidInput_ThrowsValidationException()
    {
        Action actBooleanFrom = () => Boolean.From("Not convertable string.");

        actBooleanFrom.Should().Throw<FormatException>();
    }

    [Fact]
    public void Boolean_ToString_ReturnsExpectedValue()
    {
        var boolean = Boolean.From(true);

        boolean.ToString().Should().Be(System.Boolean.TrueString);
    }
}
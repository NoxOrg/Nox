namespace Nox.Types.Tests.Types;

public class NumberTests
{
    [Fact]
    public void Number_Constructor_ReturnsSameValue()
    {
        var testNumber = 3.14m;

        var number = Number.From(testNumber);

        Assert.Equal(testNumber, number.Value);
    }

    [Fact]
    public void Number_Constructor_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        var testNumber = 3.14m;

        Assert.Throws<TypeValidationException>(() => _ =
            Number.From(testNumber, new NumberTypeOptions { MaxValue = 1 })
        );
    }

    [Fact]
    public void Number_Constructor_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        var testNumber = 3.14m;

        Assert.Throws<TypeValidationException>(() => _ =
            Number.From(testNumber, new NumberTypeOptions { MinValue = 42 })
        );
    }

    [Fact]
    public void Number_Constructor_SpecifyingDecimalDigits_WithDecimalValueInput_RoundsTheValueDown()
    {
        var testNumber = 3.14m;

        var number = Number.From(testNumber, new NumberTypeOptions { DecimalDigits = 0 });

        Assert.Equal(3, number.Value);
    }

    [Fact]
    public void Number_Constructor_SpecifyingDecimalDigits_WithDecimalValueInput_RoundsTheValueUp()
    {
        var testNumber = 3.94m;

        var number = Number.From(testNumber, new NumberTypeOptions { DecimalDigits = 0 });

        Assert.Equal(4, number.Value);
    }

    [Fact]
    public void Number_ToString_Returns_Value()
    {
        void Test()
        {
            var testNumber = 3.14m;

            var number = Number.From(testNumber);

            var numberAsString = number.ToString();

            Assert.Equal("3.14", numberAsString);
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Number_Constructor_UsingIntegralNumberTypes_ReturnsSameValue()
    {
        Number number;

        short testShort = 3;
        number = Number.From(testShort);
        Assert.Equal(testShort, number.Value);

        int testInt32 = 3;
        number = Number.From(testInt32);
        Assert.Equal(testInt32, number.Value);

        long testInt64 = 3;
        number = Number.From(testInt64);
        Assert.Equal(testInt64, number.Value);

        double testDouble = 3.141592;
        number = Number.From(testDouble);
        Assert.Equal(testDouble, (double)number.Value);

        decimal testDecimal = 3.14m;
        number = Number.From(testDecimal);
        Assert.Equal(testDecimal, number.Value);
    }

    // NOTE: Created from 'long' but will fit in 'int' based on NumberTypeOptions.DefaultMaxValue and NumberTypeOptions.DefaultMinValue
    [Theory]
    [InlineData((byte)42, typeof(decimal))]
    [InlineData((short)3, typeof(decimal))]
    [InlineData(3, typeof(decimal))]
    [InlineData((long)3, typeof(decimal))]
    [InlineData(long.MaxValue - 3, typeof(decimal))]
    [InlineData(3.141592, typeof(double))]
    public void Number_Constructor_UsingIntegralNumberTypes_ReturnsBestUnderlyingType(dynamic testValue, Type expectedType)
    {
        var number = Number.From(testValue);
        Assert.Equal(expectedType, number.GetUnderlyingType());
    }

    [Fact]
    public void Number_Constructor_UsingIntegralNumberTypesDecimal_ReturnsBestUnderlyingType()
    {
        var number = Number.From(3.14m);
        Assert.Equal(typeof(decimal), number.GetUnderlyingType());
    }
}
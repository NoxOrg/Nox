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

    [Fact]
    public void Number_Constructor_UsingIntegralNumberTypes_ReturnsBestUnderlyingType()
    {
        Number number;

        byte testByte = 42;
        number = Number.From(testByte);
        Assert.Equal(typeof(byte), number.GetUnderlyingType());

        short testShort = 3;
        number = Number.From(testShort);
        Assert.Equal(typeof(short), number.GetUnderlyingType());

        int testInt32 = 3;
        number = Number.From(testInt32);
        Assert.Equal(typeof(int), number.GetUnderlyingType());

        // NOTE: Created from 'long' but will fit in 'int' based on NumberTypeOptions.DefaultMaxValue and NumberTypeOptions.DefaultMinValue
        long testInt64 = 3;
        number = Number.From(testInt64);
        Assert.Equal(typeof(int), number.GetUnderlyingType());

        long testInt64_big = long.MaxValue - 3;
        number = Number.From(testInt64_big);
        Assert.Equal(typeof(long), number.GetUnderlyingType());

        // NOTE: double will become decimal
        double testDouble = 3.141592;
        number = Number.From(testDouble);
        Assert.Equal(typeof(decimal), number.GetUnderlyingType());

        decimal testDecimal = 3.14m;
        number = Number.From(testDecimal);
        Assert.Equal(typeof(decimal), number.GetUnderlyingType());
    }
}

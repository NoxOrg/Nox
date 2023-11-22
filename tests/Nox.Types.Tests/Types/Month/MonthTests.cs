using System.Globalization;
using FluentAssertions;

// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class MonthTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(13)]
    public void Validate_InvalidValue_ReturnsValidationFailure(byte value)
    {
        // Arrange & Act
        var exception = Assert.Throws<NoxTypeValidationException>(() => _ =  Month.From(value));
      
        // Assert
        exception.Errors.Should().Contain(e =>
            e.ErrorMessage.Contains($"Could not create a Nox Month type with unsupported value '{value}'. The value must be between 1 and 12.")
        );
    }
    
    
    [Theory]
    [InlineData(0)]
    [InlineData(13)]
    [InlineData(255)]
    [InlineData(256)]
    [InlineData(-1)]
    [InlineData(-255)]
    [InlineData(-256)]
    public void Validate_InvalidIntValue_ReturnsValidationFailure(int value)
    {
        // Arrange & Act
        var exception = Assert.Throws<NoxTypeValidationException>(() => _ =  Month.From(value));
      
        // Assert
        exception.Errors.Should().Contain(e =>
            e.ErrorMessage.Contains($"Could not create a Nox Month type with unsupported value '{value}'. The value must be between 1 and 12.")
        );
    }

    [Theory]
    [InlineData(1)]
    [InlineData(12)]
    public void Validate_ValidValue_ReturnsValidationSuccess(byte value)
    {
        // Arrange
        var month = Month.From(value);

        // Act
        var validationResult = month.Validate();

        // Assert
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().BeEmpty();
    }
    
    

    [Theory]
    [InlineData(1, "01")]
    [InlineData(12, "12")]
    public void ToString_ValidValue_ReturnsFormattedString(byte value, string expected)
    {
        // Arrange
        var month = Month.From(value);

        // Act
        var result = month.ToString();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, "Jan")]
    [InlineData(12, "Dec")]
    public void ToAbbreviatedMonthName_ValidValue_ReturnsCorrectName(byte value, string expected)
    {
        // Arrange
        var month =  Month.From(value);

        // Act
        var result = month.ToAbbreviatedMonthName();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, "January")]
    [InlineData(12, "December")]
    public void ToMonthName_ValidValue_ReturnsCorrectName(byte value, string expected)
    {
        // Arrange
        var month = Month.From(value);

        // Act
        var result = month.ToMonthName();

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1, "Ocak")]
    [InlineData(7, "Temmuz")]
    public void ToMonthName_WithCultureInfo_ValidValue_ReturnsCorrectName(byte value, string expected)
    {
        // Arrange
        var month = Month.From(value);
        CultureInfo cultureInfo = new("tr-TR");
        
        // Act
        var result = month.ToMonthName(cultureInfo);

        // Assert
        result.Should().Be(expected);
    }
}

   

// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class NoxMonthTests
{
    [Fact]
    public void Month_Constructor_ReturnsSameValue()
    {
        // Arrange & Act
        var month = Month.From(1);

        // Assert
        Assert.Equal(1, month.Value);
    }
    
    [Theory]
    [InlineData((byte)0)]
    [InlineData((byte)(13))]
    public void Month_Constructor_WithOutOfRangeMonth_ThrowsValidationException(byte value)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          Month.From(value)
        );

        // Assert
        Assert.Equal($"Could not create a Nox Month type with unsupported value '{value}'. The value must be between 1 and 12.", exception.Errors.First().ErrorMessage);
    }
    
    [Fact]
    public void Month_Equality_Tests()
    {
        // Arrange
        var month1 = Month.From(1);

        var month2 = Month.From(1);

        // Assert
        Assert.Equal(month1, month2);
    }
    
    [Fact]
    public void Month_NotEqual_Tests()
    {
        // Arrange
        var month1 = Month.From(1);

        var month2 = Month.From(2);

        // Assert
        Assert.NotEqual(month1, month2);
    }
    
    
    [Fact]
    public void Month_ToString_ReturnsString()
    {
        // Arrange
        var month = Month.From(1);
        var month2 = Month.From(12);

        // Assert
        Assert.Equal("01", month.ToString());
        Assert.Equal("12", month2.ToString());
    }
   
}
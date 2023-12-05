using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class ReferenceNumberTests
{
    [Fact]
    public void WhenUsingDefaultConstructor_ShouldReturnEmpty()
    {
        var autoNumber = new ReferenceNumber();

        autoNumber.Value.Should().BeEmpty();
    }

    [Fact]
    public void WhenReferenceNumberEquals_ShouldReturnTrue()
    {
        var initialValue = "INV-2323453";

        var refNumber1 = ReferenceNumber.FromDatabase(initialValue);
        var refNumber2 = ReferenceNumber.FromDatabase(initialValue);

        refNumber1.Should().Be(refNumber2);
    }

    [Fact]
    public void WhenCreatingReferenceNumberFromDefaultMethod_ShouldThrowException()
    {
        var action = () => ReferenceNumber.From("INV-1");

        action.Should().Throw<InvalidOperationException>();
    }
    [Theory]
    [InlineData(10,"INV","INV109")]
    [InlineData(11, "INV", "INV117")]
    [InlineData(10, "INV-", "INV-109")]
    [InlineData(10, "INV - ", "INV - 109")]
    [InlineData(256425464, "INV - ", "INV - 2564254643")]    
    public void WhenCreatingReferenceNumberFromOverloadMethod_ShouldSucceed(long number, string prefix, string expectedReference)
    {
        // Arrange Act
        var referenceNumber = ReferenceNumber.From(number, new ReferenceNumberTypeOptions() {Prefix=prefix, SuffixCheckSumDigit = true});

        // Assert
        referenceNumber.Value.Should().Be(expectedReference);
    }
    [Theory]
    [InlineData(10, "INV", "INV10")]
    [InlineData(11, "INV", "INV11")]
    [InlineData(10, "INV-", "INV-10")]
    [InlineData(10, "INV - ", "INV - 10")]
    public void WhenCreatingReferenceNumberFromOverloadMethodWithoutCheckDigit_ShouldSucceed(long number, string prefix, string expectedReference)
    {
        // Arrange Act
        var referenceNumber = ReferenceNumber.From(number, new ReferenceNumberTypeOptions() { Prefix = prefix , SuffixCheckSumDigit = false});

        // Assert
        referenceNumber.Value.Should().Be(expectedReference);
    }
}
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class AutoNumberTests
{
    private static readonly Random RandomGenerator = new();

    [Fact]
    public void AutoNumber_Constructor_ReturnsInitialValue()
    {
        var autoNumber = new AutoNumber();

        autoNumber.Value.Should().Be(0U);
    }

    [Fact]
    public void AutoNumber_GetNext_ReturnNextNumber()
    {
        var initialValue = (uint)RandomGenerator.Next();

        var autoNumber = AutoNumber.From(initialValue);

        autoNumber.GetNext().Should().Be(initialValue + 1U);
        autoNumber.GetNext().Should().Be(initialValue + 2U);
    }

    [Fact]
    public void AutoNumber_Equals_ReturnTrue()
    {
        var initialValue = (uint)RandomGenerator.Next();

        var autoNumber1 = AutoNumber.From(initialValue);
        var autoNumber2 = AutoNumber.From(initialValue);

        autoNumber1.Should().Be(autoNumber2);
    }
}
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class AutoNumberTests
{
    [Fact]
    public void AutoNumber_Constructor_ReturnsInitialValue()
    {
        var autoNumber = new AutoNumber();

        autoNumber.Value.Should().Be(0U);
    }

    [Fact]
    public void AutoNumber_Equals_ReturnTrue()
    {
        var initialValue = (uint)new Random().Next();

        var autoNumber1 = AutoNumber.FromDatabase(initialValue);
        var autoNumber2 = AutoNumber.FromDatabase(initialValue);

        autoNumber1.Should().Be(autoNumber2);
    }

    [Fact]
    public void AutoNumber_FromMethod_ThrowsException()
    {
        var action = () => AutoNumber.From(1);

        action.Should().Throw<InvalidOperationException>();
    }
}
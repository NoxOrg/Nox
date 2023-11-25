using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class ReferenceNumberTests
{
    [Fact]
    public void ReferenceNumberTests_Constructor_ReturnsInitialValue()
    {
        var autoNumber = new ReferenceNumber();

        autoNumber.Value.Should().BeEmpty();
    }

    [Fact]
    public void ReferenceNumber_Equals_ReturnTrue()
    {
        var initialValue = "INV-2323453";

        var refNumber1 = ReferenceNumber.FromDatabase(initialValue);
        var refNumber2 = ReferenceNumber.FromDatabase(initialValue);

        refNumber1.Should().Be(refNumber2);
    }

    [Fact]
    public void ReferenceNumber_FromMethod_ThrowsException()
    {
        var action = () => ReferenceNumber.From("INV-1");

        action.Should().Throw<InvalidOperationException>();
    }
}
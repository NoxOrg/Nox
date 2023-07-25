using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class DatabaseNumberTests
{
    [Fact]
    public void DatabaseNumber_Constructor_ReturnsInitialValue()
    {
        var databaseNumber = new DatabaseNumber();

        databaseNumber.Value.Should().Be(0U);
    }

    [Fact]
    public void DatabaseNumber_Equals_ReturnTrue()
    {
        var initialValue = (uint)new Random().Next();

        var databaseNumber1 = DatabaseNumber.FromDatabase(initialValue);
        var databaseNumber2 = DatabaseNumber.FromDatabase(initialValue);

        databaseNumber1.Should().Be(databaseNumber2);
    }

    [Fact]
    public void DatabaseNumber_FromMethod_ThrowsException()
    {
        var action = () => DatabaseNumber.From(1);

        action.Should().Throw<InvalidOperationException>();
    }
}
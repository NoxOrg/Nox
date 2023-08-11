using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class DatabaseGuidTests
{
    [Fact]
    public void DatabaseGuid_Constructor_ReturnsInitialValue()
    {
        var databaseGuid = new DatabaseGuid();

        databaseGuid.Value.Should().Be(Guid.Empty);
    }

    [Fact]
    public void DatabaseGuid_Equals_ReturnTrue()
    {
        var initialValue = Guid.NewGuid();

        var databaseGuid1 = DatabaseGuid.FromDatabase(initialValue);
        var databaseGuid2 = DatabaseGuid.FromDatabase(initialValue);

        databaseGuid1.Should().Be(databaseGuid2);
    }

    [Fact]
    public void DatabaseGuid_FromMethod_ThrowsException()
    {
        var action = () => DatabaseGuid.From(Guid.NewGuid());

        action.Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("DatabaseGuid can only be created with FromDatabase.");
    }
}
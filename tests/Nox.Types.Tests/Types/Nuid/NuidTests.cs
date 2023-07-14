// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class NuidTests
{
    [Fact]
    public void StringValue_CreateManyInstances_ShouldBeEqual()
    {
        const string testValue = "!#123TestValue456!#";

        var nuidLeft = Nuid.From(testValue);
        var nuidRight = Nuid.From(testValue);

        Assert.Equal(nuidLeft, nuidRight);
        Assert.Equal(nuidLeft.Value, nuidRight.Value);
        Assert.Equal(nuidLeft.ToGuid(), nuidRight.ToGuid());
        Assert.Equal(nuidLeft.ToHex(), nuidRight.ToHex());
    }
}
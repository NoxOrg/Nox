using Nox.Solution.Builders;

namespace Nox.Solution.Tests.UriBuilders;

public class RabbitMqTests
{
    [Fact]
    public void Can_build_from_serverUri()
    {
        var builder = new NoxUriBuilder(new ServerBase
        {
            Name = "Test",
            ServerUri = "rabbitmq://guest:guest@localhost"
        }, "rabbitMq", "Test description");
        var result = builder.Uri;
        Assert.NotNull(result);
        Assert.Equal("rabbitmq://guest:guest@localhost/", result.ToString());
    }

    [Fact]
    public void Can_build_from_components()
    {
        var builder = new NoxUriBuilder(new ServerBase
        {
            Name = "Test",
            ServerUri = "localhost",
            User = "guest",
            Password = "guest",
            Port = 5672
        }, "rabbitMq", "Test description");
        var result = builder.Uri;
        Assert.NotNull(result);
        Assert.Equal("rabbitmq://guest:guest@localhost:5672/", result.ToString());
    }
    
}
#nullable enable
namespace ClientApi.Application.Jobs;

public partial class HelloWorldJob
{
    public override Task Run()
    {
        Logger.LogInformation("Hello World");
        return Task.CompletedTask;
    }
}
#nullable enable
using Microsoft.Extensions.Logging;
using Nox.Application.Jobs;

namespace ClientApi.Application.Jobs;

public partial class HelloWorldJob
{
    public override void Run()
    {
        Logger.LogInformation("Hello World");
    }
}
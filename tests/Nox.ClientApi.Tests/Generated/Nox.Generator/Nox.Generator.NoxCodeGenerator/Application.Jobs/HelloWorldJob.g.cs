#nullable enable
using Microsoft.Extensions.Logging;
using Nox.Application.Jobs;

namespace ClientApi.Application.Jobs;

[NoxJob("HelloWorld", "*/1 * * * *")]
public partial class HelloWorldJob : JobBase
{
     public HelloWorldJob(ILogger<IJob> logger) : base(logger)
     {
     }
}
#nullable enable
using Microsoft.Extensions.Logging;
using Nox.Application.Jobs;

namespace {{codeGenConventions.ApplicationNameSpace}}.Jobs;

[NoxJob("{{job.Name}}", "{{job.RecurrentCronExpression}}")]
public partial class {{className}} : JobBase
{
     public {{className}}(ILogger<IJob> logger) : base(logger)
     {
     }
}
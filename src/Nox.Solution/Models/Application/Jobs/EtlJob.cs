using Nox.Yaml.Attributes;
using System.Diagnostics;

namespace Nox.Solution.Models.Application.Jobs
{
    [GenerateJsonSchema]
    [Title("Defines a Job to be executed by the application")]
    [AdditionalProperties(false)]
    [DebuggerDisplay("{Name}: {RecurrentCronExpression}")]
    public class EtlJob 
    {
        [Required]
        [Title("The Name of the Job. Contains no spaces.")]
        [Description("Unique Name of the job used for job identification, code generation, logs and monitoring")]
        [Pattern(Nox.Yaml.Constants.StringWithNoSpacesRegex)]
        public string Name { get; internal set; } = null!;

        [Required]
        [Title("The Job description.")]
        public string Description { get; internal set; } = null!;

        [Required]
        [Title("The job scheduler in a Cron Expression format")]
        [Description("A Job is executed recurrently by setting up this expression")]
        [Pattern(Nox.Yaml.Constants.CronExpressionRegex)]
        public string RecurrentCronExpression { get; internal set; } = null!;
    }
}

using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[Title("Scheduling of the Integration.")]
[Description("Specify when and how frequently the Integration source is checked for updates, as well as the retry policy in case of failure. Includes a switch to indicate whether update is triggered at application startup.")]
[AdditionalProperties(false)]
public class IntegrationSchedule
{
    [Required]
    [Title("Start time to check the Integration source for updates.")]
    [Description("Specify the start time to check the Integration source for updates. This is a 'speak-friendly' phrase that comprises the trigger time as well as the frequency. Translated into a cron expression.")]
    public string Start { get; internal set; } = null!;

    // These descriptors should be moved to the class when the generator is fixed
    [Title("Retry policy applying to the Integration source updates.")]
    [Description("This outlines the retry configuration in the case of Integration engine being unable to connect to the Integration data source. Includes limit and delay before retry.")]
    [AdditionalProperties(false)]
    public IntegrationScheduleRetryPolicy? Retry { get; internal set; }

    [Title("Check the Integration source for updates at appliation startup.")]
    [Description("Specify here whether the Integration source is checked for updates when the application starts.")]
    public bool? RunOnStartup { get; internal set; } = false;
}
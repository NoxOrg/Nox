using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Scheduling of the ETL source.")]
    [Description("Specify when and how frequently the ETL source is checked for updates, as well as the retry policy in case of failure. Includes a switch to indicate whether update is triggered at application startup.")]
    [AdditionalProperties(false)]
    public class IntegrationSchedule
    {
        [Required]
        [Title("Start time to check the ETL source for updates.")]
        [Description("Specify the start time to check the ETL source for updates. This is a 'speak-friendly' phrase that comprises the trigger time as well as the frequency. Translated into a cron expression.")]
        public string Start { get; internal set; } = null!;

        // These descriptors should be moved to the class when the generator is fixed
        [Title("Retry policy applying to the ETL source updates.")]
        [Description("This outlines the retry configuration in the case of ETL engine being unable to connect to the ETL data source. Includes limit and delay before retry.")]
        [AdditionalProperties(false)]
        public IntegrationScheduleRetryPolicy? Retry { get; internal set; }

        [Title("Check the ETL source for updates at appliation startup.")]
        [Description("Specify here whether the ETL source is checked for updates when the application starts.")]
        public bool? RunOnStartup { get; internal set; }
    }
}
using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for the email server used in a Nox solution.")]
    [Description("Specify properties pertinent to the solution email server here. Examples include name, serverUri, Port, connection credentials and provider.")]
    [AdditionalProperties(false)]
    public class EmailServer: ServerBase
    {
        [Required]
        [Title("The email server provider.")]
        [Description("The provider used for this email server. Examples include SendGrid and MailChimp.")]
        [AdditionalProperties(false)]
        public EmailServerProvider Provider { get; internal set; } = EmailServerProvider.SendGrid;
    }
}
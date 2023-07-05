using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for the validity period of secrets as defined in a Nox solution.")]
    [Description("Specify the validity period of secrets pertaining to the solution here. Possible units of measure include days, hours, minutes and seconds.")]
    [AdditionalProperties(false)]
    public class SecretsValidFor
    {
        public int? Days { get; internal set; }
        public int? Hours { get; internal set; }
        public int? Minutes { get; internal set; }
        public int? Seconds { get; internal set; }
    }
}
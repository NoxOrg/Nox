using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;

namespace Nox.Solution;

[Title("The definition namespace for the validity period of secrets as defined in a Nox solution.")]
[Description("Specify the validity period of secrets pertaining to the solution here. Possible units of measure include days, hours, minutes and seconds.")]
[AdditionalProperties(false)]
public class SecretsValidFor : YamlConfigNode<NoxSolution,SecretsServer>
{
    public int? Days { get; internal set; }
    public int? Hours { get; internal set; }
    public int? Minutes { get; internal set; }
    public int? Seconds { get; internal set; }


    public override ValidationResult Validate(NoxSolution topNode, SecretsServer parentNode, string yamlPath)
    {
        var result = new ValidationResult();

        if (!HaveValidTimespan())
        {
            result.Errors.Add(new ValidationFailure( nameof(parentNode.ValidFor), $"The secrets 'valid for' must have a valid time span specified." ));
        }

        return result;
    }

    private bool HaveValidTimespan()
    {
        if (Days == null && Hours == null && Minutes == null && Seconds == null) return false;
        var tally = 0;
        tally += Days ?? 0;
        tally += Hours ?? 0;
        tally += Minutes ?? 0;
        tally += Seconds ?? 0;
        return (tally > 0);
    }
}


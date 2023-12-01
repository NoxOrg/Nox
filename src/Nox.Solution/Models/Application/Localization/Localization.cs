using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Nox.Yaml;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The localization settings for the solution.")]
[Description("The supported localization and defaults for the solution.")]
[AdditionalProperties(false)]
public class Localization : YamlConfigNode<NoxSolution, Application>
{
    [Title("The list of culture codes supported by the solution.")]
    [Description("The list of culture codes that the solution supports.")]
    [Pattern(@"^[a-z]{2}(?:-[A-Z]{2})?(?:-[A-Z][a-z]{3})?$")]
    [Required]
    public IReadOnlyList<string> SupportedCultures { get; set; } = new List<string>() { "en-US" };

    [Title("The default culture code for the solution.")]
    [Description("The default culture code used for formatting and translation.")]
    [Pattern(@"^[a-z]{2}(?:-[A-Z]{2})?(?:-[A-Z][a-z]{3})?$")]
    [Required]
    public string DefaultCulture { get; set; } = "en-US";

    public override void SetDefaults(NoxSolution topNode, Application parentNode, string yamlPath)
    {
        SupportedCultures = SupportedCultures.Append(DefaultCulture).ToImmutableHashSet().ToList();
        base.SetDefaults(topNode, parentNode, yamlPath);
    }
}
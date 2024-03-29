using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Nox.Types;
using Nox.Types.Abstractions.Extensions;
using Nox.Yaml;
using Nox.Yaml.Attributes;
using YamlDotNet.Serialization;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The localization settings for the solution.")]
[Description("The supported localization and defaults for the solution.")]
[AdditionalProperties(false)]
public class Localization : YamlConfigNode<NoxSolution, Application>
{
    [Title("The list of culture codes supported by the solution.")]
    [Description("The list of culture codes that the solution supports.")]
    [Required]
    public IReadOnlyList<Culture> SupportedCultures { get; set; } = new List<Culture>() { Culture.en_US };

    [YamlIgnore]
    public  HashSet<string> SupportedCulturesDisplayNames { get; private set; } = new HashSet<string>();

    [Title("The default culture code for the solution.")]
    [Description("The default culture code used for formatting and translation.")]
    [Required]
    
    public Culture DefaultCulture { get; set; } = Culture.en_US;

    public override void SetDefaults(NoxSolution topNode, Application parentNode, string yamlPath)
    {
        SupportedCultures = SupportedCultures.Append(DefaultCulture).ToImmutableHashSet().ToList();
        foreach (var culture in SupportedCultures)
            SupportedCulturesDisplayNames.Add(culture.ToDisplayName());

        base.SetDefaults(topNode, parentNode, yamlPath);
    }
}
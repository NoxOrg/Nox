
using Nox.Types.Schema;
using System.Collections.Generic;

namespace Nox.Types;

[Title("Options for the enum value type.")]
[Description("Options to control the behaviour of the Enum nox type.")]
[AdditionalProperties(false)]
public class EnumerationTypeOptions : INoxTypeOptions
{
    [Title("The optional default values for this Enum.")]
    [Description("The default evalues of this Enum. These values will automatically be created and available in the domain.")]
    public IReadOnlyList<EnumerationValues> Values { get; set; } = System.Array.Empty<EnumerationValues>();

    [Title("Whether the description of the Enum will be localizable.")]
    [Description("Whether the description of the Enum will be localizable for the supported solution cultures")]
    public bool IsLocalized { get; set; } = true;
}


public class EnumerationValues
{
    [Required]
    [Title("The Id for the Enum.")]
    [Description("The Enum identifier. This value will be persisted with entities and should uniquely identify an entry.")]
    public int Id { get; set; }

    [Required]
    [Title("The friendly name of the Enum value. Contains no spaces.")]
    [Description("The name in the default culture of the Enum identifier.")]
    public string Name { get; set; } = default!;
}
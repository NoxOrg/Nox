// Generated

#nullable enable

using Microsoft.AspNetCore.Components;

namespace {{codeGeneratorState.UiNameSpace}}.Components;

public partial class NavigationMenu : ComponentBase
{
    {{- for entity in entities }}
    
    public string {{entity.PluralName}}Icon { get; set; } = "";    
    public string {{entity.PluralName}}PageLink { get; set; } = "{{entity.PluralName}}";

    {{- end }}
}
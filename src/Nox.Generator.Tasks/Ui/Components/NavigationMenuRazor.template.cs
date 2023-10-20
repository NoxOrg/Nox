@*Generated *@

@namespace {{codeGeneratorState.UiNameSpace}}.Components;
@inherits NavigationMenu 

Navigation Menu Component
@*
<MudNavMenu Style="margin-top:20px;">    
    {{- for entity in entities }}

    <MudNavLink Match = "NavLinkMatch.Prefix" Icon = "@{{entity.PluralName}}Icon" IconColor = "Color.Inherit" Href = "@{{entity.PluralName}}PageLink" ActiveClass = "custom-linkHighlighted" >{{ entity.PluralName}}</MudNavLink>
    {{- end }}
</MudNavMenu >
*@
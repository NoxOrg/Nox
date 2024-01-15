// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace {{codeGenConventions.DomainNameSpace}};

/// <summary>
/// Static methods for the {{entity.Name}} class.
/// </summary>
public partial class {{className}}
{
{{- for entityMetaData in entitiesMetaData }}
    {{ if entityMetaData.HasTypeOptions == true && entityMetaData.Type != "AutoNumber" }}
    /// <summary>
    /// Type options for property '{{entityMetaData.Name}}'
    /// </summary>
    public static Nox.Types.{{entityMetaData.Type}}TypeOptions {{entityMetaData.Name}}TypeOptions {get; private set;} = new ()
    {
        {{- for property in entityMetaData.OptionsProperties }}
        {{property}}
        {{- end }}
    };


    /// <summary>
    /// Factory for property '{{entityMetaData.Name}}'
    /// </summary>
    public static Nox.Types.{{entityMetaData.Type}} Create{{entityMetaData.Name}}({{entityMetaData.InParams}})
        => Nox.Types.{{entityMetaData.Type}}.From(value, {{entityMetaData.Name}}TypeOptions);
    {{ else }}
    /// <summary>
    /// Factory for property '{{entityMetaData.Name}}'
    /// </summary>
    public static Nox.Types.{{entityMetaData.Type}} Create{{entityMetaData.Name}}({{entityMetaData.InParams}})
        => Nox.Types.{{entityMetaData.Type}}.{{ if entityMetaData.Type == "AutoNumber" }}FromDatabase{{ else }}From{{ end }}(value);
    {{ end }}
{{- end }}

    {{- for attribute in entity.Attributes }}

        {{- hasUserInterface = attribute.UserInterface }}
        /// <summary>
        /// User Interface for property '{{attribute.Name}}'
        /// </summary>
        public static TypeUserInterface? {{attribute.Name}}UiOptions {get; private set;} ={{ if !(attribute.UserInterface) }} null; {{ else }} new()
        {
            {{- ui = attribute.UserInterface }}
        {{~ if ui.Label ~}}    
            Label = "{{ui.Label}}", 
        {{~ end ~}}
        {{~ if ui.Widget ~}}    
            Widget = Widget.{{ui.Widget}}, 
        {{~ end ~}}
        {{~ if ui.Icon ~}}   
            Icon = "{{ui.Icon}}", 
        {{~ end ~}}
        {{~ if ui.IconPosition ~}}    
            IconPosition = IconPosition.{{ui.IconPosition}}, 
        {{~ end ~}}
        {{~ if ui.InputMask ~}}    
            InputMask = "{{ui.InputMask}}", 
        {{~ end ~}}
        {{~ if ui.OutputMask ~}}    
            OutputMask = "{{ui.OutputMask}}",
        {{~ end ~}}
        {{~ if ui.Regex ~}}    
            Regex = "{{ui.Regex}}", 
        {{~ end ~}}
        {{~ if ui.PageGroup ~}}    
            PageGroup = "{{ui.PageGroup}}",
        {{~ end ~}}
        {{~ if ui.FieldGroup ~}}    
            FieldGroup = "{{ui.FieldGroup}}", 
        {{~ end ~}}
        {{~ if ui.HelpHint ~}}    
            HelpHint = "{{ui.HelpHint}}", 
        {{~ end ~}}
        {{~ if ui.ErrorMessage ~}}    
            ErrorMessage = "{{ui.ErrorMessage}}", 
        {{~ end ~}}
            InputOrder = {{ui.InputOrder}},
            ShowInSearchResults = ShowInSearchResultsOption.{{ui.ShowInSearchResults}},
            {{~ ## Generate boolean parameters if their values are not default ## ~}}
        {{~ if ui.CanSort == true ~}}   
            CanSort = {{ui.CanSort}},
        {{~ end ~}}
        {{~ if ui.CanSearch == true ~}}
            CanSearch = {{ui.CanSearch}}, 
        {{~ end ~}}
        {{~ if ui.CanFilter == true ~}}
            CanFilter = {{ui.CanFilter}},
        {{~ end ~}}
        {{~ if ui.ShowOnCreateForm == false ~}}
            ShowOnCreateForm = {{ui.ShowOnCreateForm}},
        {{~ end ~}}
        {{~ if ui.ShowOnUpdateForm == false ~}}
            ShowOnUpdateForm = {{ui.ShowOnUpdateForm}},
        {{~ end ~}}
        }; {{ end }}
           
    {{- end }}
}
using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditFormula : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public FormulaTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public string Expression { get; set; } = string.Empty;

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            Expression = TypeOptions.Expression;
        }
    }
}
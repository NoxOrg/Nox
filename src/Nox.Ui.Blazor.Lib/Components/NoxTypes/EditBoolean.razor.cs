using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditBoolean : ComponentBase
{

    #region Declarations

    [Parameter]
    public bool? Boolean { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<bool?> BooleanChanged { get; set; }

    #endregion

    protected async Task OnBooleanChanged(bool? newValue)
    {
        Boolean = newValue;

        await BooleanChanged.InvokeAsync(Boolean);
    }
}
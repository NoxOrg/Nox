using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditGuid : ComponentBase
{
    #region Declarations

    [Parameter]
    public Guid? Guid { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public EventCallback<Guid?> GuidChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    #endregion

    protected async Task OnGuidChanged(string newValue)
    {
        if(System.Guid.TryParse(newValue, out Guid result))
        {
            Guid = result;
        }
        else
        {
            Guid = null;
        }
        await GuidChanged.InvokeAsync(Guid);
    }
}
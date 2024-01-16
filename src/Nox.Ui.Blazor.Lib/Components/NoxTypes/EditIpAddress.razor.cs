using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditIpAddress : ComponentBase
{

    #region Declarations

    [Parameter]
    public string? IpAddress { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string Type { get; set; } = "IpV4";

    [Parameter]
    public EventCallback<string> IpAddressChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    [Parameter]
    public int MaxLength { get; set; } = 63;

    #endregion

    protected async Task OnIpAddressChanged(string newValue)
    {
        IpAddress = newValue;

        await IpAddressChanged.InvokeAsync(IpAddress);
    }

    public IMask DisplayMask()
    {
        switch (Type.Trim().ToLower())
        {
            case "ipv4":
            default:
                return RegexMask.IPv4();
        }
    }
}
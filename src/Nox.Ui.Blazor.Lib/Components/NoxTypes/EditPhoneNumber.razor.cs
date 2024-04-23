using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditPhoneNumber : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? PhoneNumber { get; set; }

    [Parameter]
    public EventCallback<string?> PhoneNumberChanged { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    [Parameter]
    public int MaxLength { get; set; } = 30;

    protected async Task OnPhoneNumberChanged(string newValue)
    {
        PhoneNumber = newValue;

        await PhoneNumberChanged.InvokeAsync(PhoneNumber);
    }

    public string Validate(string arg)
    {
        if (!string.IsNullOrWhiteSpace(arg))
        {
            try
            {
                Types.PhoneNumber.From(arg);
            }
            catch (NoxTypeValidationException)
            {
                return String.Format(Resources.Resources.ValidateGeneric, arg, Title ?? string.Empty).Trim();
            }
        }

        return String.Empty;
    }
}
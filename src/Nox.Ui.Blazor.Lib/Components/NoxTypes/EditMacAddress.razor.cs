using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditMacAddress : ComponentBase
{

    #region Declarations

    [Parameter]
    public string? MacAddress { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public EventCallback<string> MacAddressChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    [Parameter]
    public string Format { get; set; } = "##:##:##:##:##:##";

    #endregion

    protected async Task OnMacAddressChanged(string newValue)
    {
        MacAddress = newValue;

        await MacAddressChanged.InvokeAsync(MacAddress);
    }

    public IMask DisplayMask()
    {
        return new PatternMask(Format)
        {
            MaskChars = new[] { new MaskChar('#', @"[0-9a-fA-F]") },
            CleanDelimiters = true,
            Transformation = AllUpperCase
        };
    }

    private static char AllUpperCase(char c) => Char.ToUpper(c);
}
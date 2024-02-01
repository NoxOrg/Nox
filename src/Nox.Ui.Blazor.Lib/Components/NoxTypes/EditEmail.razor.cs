using Microsoft.AspNetCore.Components;
using Nox.Extensions;
using Nox.Types;
using Nox.Yaml.Attributes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditEmail : ComponentBase
{
    #region Declarations

    [Parameter]
    public string? Email { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    [Parameter]
    public int MaxLength { get; set; } = 255;

    [Parameter]
    public bool Required { get; set; } = false;

    #endregion

    protected async Task OnTextChanged(string newValue)
    {
        Email = newValue;

        await TextChanged.InvokeAsync(Email);
    }

    public string Validate(string arg)
    {
        if (!string.IsNullOrWhiteSpace(arg))
        { 
            try
            {
                Types.Email.From(arg);
            }
            catch (NoxTypeValidationException)
            {
                return String.Format(Resources.Resources.ValidateGeneric, arg, Title ?? string.Empty).Trim();
            }
        }
           
        return String.Empty;
    }
}
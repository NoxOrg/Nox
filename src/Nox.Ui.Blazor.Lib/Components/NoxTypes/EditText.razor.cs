using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditText : ComponentBase
{

    #region Declarations

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    [Parameter]
    public int MaxLength { get; set; } = 63;

    [Parameter]
    public int MinLength { get; set; } = 0;

    [Parameter]
    public TextTypeOptions? TypeOptions { get; set; }

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MaxLength = (int)TypeOptions.MaxLength;
            MinLength = (int)TypeOptions.MinLength;
        }
    }

    protected async Task OnTextChanged(string newValue)
    {
        Text = newValue;

        await TextChanged.InvokeAsync(Text);
    }

    public string ValidateLength(string arg)
    {
        if (arg != null
            && arg.Length < MinLength)
            return String.Format(Resources.Resources.ValidateTextLength, Title, MinLength.ToString()).Trim();
        return String.Empty;
    }
}
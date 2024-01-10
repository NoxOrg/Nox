using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditText : ComponentBase
{

    #region Declarations

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    [Parameter]
    public int MaxLength { get; set; } = 63;

    [Parameter]
    public int MinLength { get; set; } = 0;

    #endregion

    protected async Task OnTextChanged(string newValue)
    {
        Text = newValue;

        await TextChanged.InvokeAsync(Text);
    }

    public string ValidateLength(string arg)
    {
        if (arg != null
            && arg.Length < MinLength)
            return String.Format(Resources.Resources.TextValidateLength, Title, MinLength.ToString()).Trim();
        return String.Empty;
    }
}
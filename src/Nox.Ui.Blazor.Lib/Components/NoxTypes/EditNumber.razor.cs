using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditNumber<T> : ComponentBase where T : struct
{
    #region Declarations

    [Parameter]
    public T? Number { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public decimal? Minimum { get; set; }

    [Parameter]
    public decimal? Maximum { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public EventCallback<T?> NumberChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    #endregion

    protected async Task OnNumberChanged(string newValue)
    {
        if (TryParse(newValue, out T parsedValue))
        {
            Number = parsedValue;
        }
        else
        {
            Number = null;
        }
        await NumberChanged.InvokeAsync(Number);
    }

    private static bool TryParse(string value, out T result)
    {
        try
        {
            result = (T)Convert.ChangeType(value, typeof(T));
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }
}
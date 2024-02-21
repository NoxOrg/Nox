using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditNumber<T> : ComponentBase where T : struct
{
    #region Declarations

    [Parameter]
    public T? Number { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public decimal? Minimum { get; set; }

    [Parameter]
    public decimal Maximum { get; set; } = 100;

    [Parameter]
    public uint DecimalDigits { get; set; } = 2;

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

    [Parameter]
    public NumberTypeOptions? TypeOptions { get; set; }

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            Minimum = TypeOptions.MinValue;
            Maximum = TypeOptions.MaxValue;
            DecimalDigits = TypeOptions.DecimalDigits;
        }
    }

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
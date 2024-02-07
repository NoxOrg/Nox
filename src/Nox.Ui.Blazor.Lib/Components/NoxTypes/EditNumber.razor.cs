using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditNumber : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Number { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    [Parameter]
    public decimal MinValue { get; set; } = 0;

    [Parameter]
    public decimal MaxValue { get; set; } = 100;

    [Parameter]
    public uint DecimalDigits { get; set; } = 2;

    [Parameter]
    public EventCallback<decimal?> NumberChanged { get; set; }

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
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
            DecimalDigits = TypeOptions.DecimalDigits;
        }
    }

    protected async Task OnNumberChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedInt))
        {
            Number = parsedInt;
        }
        else
        {
            Number = null;
        }

        await NumberChanged.InvokeAsync(Number);
    }
}
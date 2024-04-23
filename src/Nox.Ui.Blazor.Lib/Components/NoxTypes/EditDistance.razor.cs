using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditDistance : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Distance { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    [Parameter]
    public EventCallback<decimal?> DistanceChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    [Parameter]
    public string? AdornmentIcon { get; set; }

    [Parameter]
    public DistanceTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public double MinValue { get; set; } = 0;

    [Parameter]
    public double MaxValue { get; set; } = 100;

    [Parameter]
    public DistanceTypeUnit Units { get; set; } = DistanceTypeUnit.Kilometer;

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
            Units = TypeOptions.Units;
        }
    }

    protected async Task OnDistanceChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDouble))
        { 

            Distance = parsedDouble;
        }
        else
        {
            Distance = null;
        }

        await DistanceChanged.InvokeAsync(Distance);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (Units == DistanceTypeUnit.Mile)
        {
            return Icon.DistanceUnit_Mile;
        }

        if (Units == DistanceTypeUnit.Kilometer)
        {
            return Icon.DistanceUnit_Kilometer;
        }

        return String.Empty;
    }
}
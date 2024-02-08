using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditArea : ComponentBase
{

    #region Declarations

    [Parameter]
    public Decimal? Area { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<Decimal?> AreaChanged { get; set; }

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
    public AreaTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public double MinValue { get; set; } = 0;

    [Parameter]
    public double MaxValue { get; set; } = 100;

    [Parameter]
    public AreaTypeUnit Units { get; set; } = AreaTypeUnit.SquareMeter;

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

    protected async Task OnAreaChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDouble))
        {
            Area = parsedDouble;
        }
        else
        {
            Area = null;
        }

        await AreaChanged.InvokeAsync(Area);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (Units == AreaTypeUnit.SquareFoot)
        {
            return Icon.AreaUnit_SquareFoot;
        }

        if (Units == AreaTypeUnit.SquareMeter)
        {
            return Icon.AreaUnit_SquareMeter;
        }
        return String.Empty;
    }
}
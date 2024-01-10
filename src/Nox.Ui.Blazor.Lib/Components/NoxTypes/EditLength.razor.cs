using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditLength : ComponentBase
{

    #region Declarations

    [Parameter]
    public Decimal? Length { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public LengthUnit LengthUnit { get; set; } = LengthUnit.Meter;

    [Parameter]
    public EventCallback<Decimal?> LengthChanged { get; set; }

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

    #endregion

    protected async Task OnLengthChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDouble))
        { 
            Length = parsedDouble;
        }
        else
        {
            Length = null;
        }

        await LengthChanged.InvokeAsync(Length);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (LengthUnit == LengthUnit.Foot)
        {
            return Icon.LengthUnit_Foot;
        }

        if (LengthUnit == LengthUnit.Meter)
        {
            return Icon.LengthUnit_Meter;
        }

        return String.Empty;

    }
}
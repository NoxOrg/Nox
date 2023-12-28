using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditArea : ComponentBase
{

    #region Declarations

    [Parameter]
    public Decimal? Area { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public AreaUnit AreaUnit { get; set; } = AreaUnit.SquareMeter;

    [Parameter]
    public EventCallback<Decimal?> AreaChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return Title + " is required";
        }
    }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    [Parameter]
    public string? AdornmentIcon { get; set; }

    #endregion

    protected async Task OnAreaChanged(string newValue)
    {
    if (decimal.TryParse(newValue, out decimal parsedDecimal))
        Area = parsedDecimal;
    else
        Area = null;
        {
            _ = decimal.TryParse(newValue, out decimal parsedDouble);

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

        if (AreaUnit == AreaUnit.SquareFoot)
        {
            return "<path d=\"m5.42,18.58v-7.42h-1.17v-1.19h1.17v-.41c0-1.21.26-2.31.96-3.01.57-.57,1.32-.8,2.02-.8.53,0,.99.12,1.29.25l-.21,1.21c-.22-.11-.53-.2-.96-.2-1.29,0-1.61,1.17-1.61,2.49v.46h2v1.19h-2v7.42h-1.49Z\"/><path d=\"m12.27,7.49v2.47h2.16v1.19h-2.16v4.64c0,1.07.29,1.67,1.13,1.67.39,0,.69-.05.87-.11l.07,1.17c-.29.12-.75.21-1.34.21-.7,0-1.27-.23-1.63-.66-.43-.46-.58-1.23-.58-2.24v-4.7h-1.29v-1.19h1.29v-2.06l1.47-.41Z\"/><path d=\"m15.08,13.19l1.08-1.05c1.42-1.33,2.16-2.17,2.16-3.08,0-.68-.41-1.25-1.3-1.25-.6,0-1.11.32-1.44.55l-.36-.8c.46-.41,1.23-.75,2.09-.75,1.61,0,2.28,1.05,2.28,2.01,0,1.33-.98,2.31-2.28,3.5l-.53.5v.04h2.93v.98h-4.63v-.66Z\"/>";
        }

        if (AreaUnit == AreaUnit.SquareMeter)
        {
            return "<path class=\"cls-1\" d=\"m1.09,9.48c0-.85-.02-1.55-.07-2.23h1.31l.07,1.33h.05c.46-.78,1.23-1.52,2.59-1.52,1.13,0,1.98.68,2.34,1.65h.03c.26-.46.58-.82.92-1.07.49-.38,1.04-.58,1.82-.58,1.09,0,2.71.72,2.71,3.58v4.86h-1.47v-4.67c0-1.59-.58-2.54-1.79-2.54-.85,0-1.52.63-1.77,1.36-.07.2-.12.48-.12.75v5.1h-1.47v-4.94c0-1.31-.58-2.27-1.72-2.27-.94,0-1.62.75-1.86,1.5-.08.22-.12.48-.12.73v4.98h-1.47v-6.02Z\"/><path class=\"cls-1\" d=\"m14.51,9.82v-.54l.69-.67c1.65-1.57,2.39-2.4,2.4-3.38,0-.66-.32-1.26-1.28-1.26-.59,0-1.07.3-1.37.55l-.28-.62c.45-.38,1.08-.66,1.83-.66,1.39,0,1.98.95,1.98,1.88,0,1.19-.86,2.15-2.23,3.47l-.52.48v.02h2.9v.73h-4.12Z\"/>";
        }

        return String.Empty;
    }
}
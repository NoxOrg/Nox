using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewCurrencyNumber : ComponentBase
{
    [Parameter]
    public short? CurrencyNumber { get; set; }
}
using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewCountryNumber : ComponentBase
{
    [Parameter]
    public ushort? CountryNumber { get; set; }
}
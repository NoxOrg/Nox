using Microsoft.AspNetCore.Components;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewVatNumber : ComponentBase
{
    [Parameter]
    public VatNumberModel? VatNumber { get; set; }
}
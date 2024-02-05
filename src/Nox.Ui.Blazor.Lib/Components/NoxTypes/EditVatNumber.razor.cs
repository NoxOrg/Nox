using Microsoft.AspNetCore.Components;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditVatNumber : ComponentBase
{
    [Parameter]
    public VatNumberModel? VatNumber { get; set; }

    [Parameter]
    public EventCallback<VatNumberModel?> VatNumberChanged { get; set; }

}
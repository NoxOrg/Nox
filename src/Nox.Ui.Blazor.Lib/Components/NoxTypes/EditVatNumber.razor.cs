using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditVatNumber : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public VatNumberModel? VatNumber { get; set; }

    [Parameter]
    public EventCallback<VatNumberModel?> VatNumberChanged { get; set; }

    [Parameter]
    public VatNumberTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public CountryCode CountryCode { get; set; }

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            CountryCode = TypeOptions.CountryCode;
        }
    }
}
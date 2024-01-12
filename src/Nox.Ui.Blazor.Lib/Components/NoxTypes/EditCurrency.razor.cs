using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditCurrency : ComponentBase
{

    #region Declarations

    [Parameter]
    public CurrencyModel? Currency { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public List<CurrencyModel> CurrencySelectionList { get; set; } = new();

    [Parameter]
    public EventCallback<CurrencyModel?> CurrencyChanged { get; set; }

    public string? CurrentCurrencyIdStr { get; set; }

    public CurrencyModel? CurrentCurrency { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    #endregion

    protected async Task OnCurrencyIdChanged(string newValue)
    {
        CurrentCurrencyIdStr = newValue;

        if (!String.IsNullOrWhiteSpace(CurrentCurrencyIdStr)
            && CurrencySelectionList != null)
        {
            Currency = CurrencySelectionList.Find(Currency => String.Equals(Currency.Id, CurrentCurrencyIdStr, StringComparison.CurrentCultureIgnoreCase));
        }

        await CurrencyChanged.InvokeAsync(Currency);
    }
}
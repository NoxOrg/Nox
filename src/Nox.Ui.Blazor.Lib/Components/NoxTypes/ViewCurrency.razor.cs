using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewCurrency : ComponentBase
{

    #region Declarations

    [Parameter]
    public CurrencyModel? Currency { get; set; }

    public string DisplayCurrency
    {

        get
        {
            if (Currency != null
                && !String.IsNullOrWhiteSpace(Currency.Name))
            {
                return Currency.Name;
            }

            return String.Empty;
        }
    }

    #endregion
}
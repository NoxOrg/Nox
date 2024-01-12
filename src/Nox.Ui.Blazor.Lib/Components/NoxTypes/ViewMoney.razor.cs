using Microsoft.AspNetCore.Components;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewMoney : ComponentBase
{

    #region Declarations

    [Parameter]
    public MoneyModel? Money { get; set; }

    [Parameter]
    public string Format { get; set; } = "{0:#,##0.##}";

    [Parameter]
    public string Symbol { get; set; } = string.Empty;

    [Parameter]
    public bool SpaceBetweenAmountAndSymbol { get; set; } = false;

    [Parameter]
    public bool SymbolOnLeft { get; set; } = true;

    public string DisplayMoney { 
        
        get
        {
            if (Money != null)
            {
                string SymbolSeparator = string.Empty;
                if (SpaceBetweenAmountAndSymbol)
                {
                    SymbolSeparator = " ";
                }

                if (SymbolOnLeft)
                {
                    return Symbol
                    + SymbolSeparator
                    + String.Format(Format, Money.Amount).Trim();
                }
                else
                {
                    return String.Format(Format, Money.Amount).Trim()
                    + SymbolSeparator
                    + Symbol;
                }                                   
            }

            return String.Empty;
        }
    }

    #endregion
}
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Cryptocash.Application.Dto;
using Microsoft.SqlServer.Server;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewMoneyBase : ComponentBase
    {
#nullable enable

        #region Declarations

        [Parameter]
        public MoneyDto? Money { get; set; }

        [Parameter]
        public CurrencyDto? Currency { get; set; }

        public string DisplayMoney { 
            
            get
            {
                if (Money != null
                    && Currency != null)
                {
                    string CurrencyFormat = "{0:#.##}";

                    if (!String.IsNullOrWhiteSpace(Currency.ThousandsSeparator)
                        && !String.IsNullOrWhiteSpace(Currency.DecimalSeparator))
                    {
                        CurrencyFormat = "{" + $"0:#{Currency.ThousandsSeparator}##0{Currency.DecimalSeparator}"
                            + String.Concat("#", Currency.DecimalDigits) 
                            + "}";
                    }

                    string SymbolSeparator = "";
                    if (Currency.SpaceBetweenAmountAndSymbol)
                    {
                        SymbolSeparator = " ";
                    }

                    return Currency.Symbol 
                        + SymbolSeparator 
                        + String.Format(CurrencyFormat, Money.Amount).Trim();                    
                }

                return String.Empty;
            }
        }

        #endregion
    }
}
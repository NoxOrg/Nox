using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Cryptocash.Application.Dto;
using Microsoft.SqlServer.Server;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewCurrencyBase : ComponentBase
    {
#nullable enable

        #region Declarations

        [Parameter]
        public CurrencyDto? Currency { get; set; }

        public string DisplayCurrency { 
            
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
}
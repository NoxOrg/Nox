using Cryptocash.Application.Dto;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using System.Text.RegularExpressions;
using System.Web;
using static MongoDB.Driver.WriteConcern;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditCurrencyBase : ComponentBase
    {
#nullable enable

        #region Declarations

        [Parameter]
        public CurrencyDto? Currency { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public List<CurrencyDto> CurrencySelectionList { get; set; } = new();

        [Parameter]
        public EventCallback<CurrencyDto?> CurrencyChanged { get; set; }

        public string? CurrentCurrencyIdStr { get; set; }

        public CurrencyDto? CurrentCurrency { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title + " is required";
            }
        }

        #endregion

        protected async Task OnCurrencyIdChanged(string newValue)
        {
            CurrentCurrencyIdStr = newValue;

            if (!String.IsNullOrWhiteSpace(CurrentCurrencyIdStr)
                && CurrencySelectionList != null)
            {
                Currency = CurrencySelectionList.FirstOrDefault(Currency => String.Equals(Currency.Id, CurrentCurrencyIdStr, StringComparison.CurrentCultureIgnoreCase));
            }

            await CurrencyChanged.InvokeAsync(Currency);
        }
    }
}
using Cryptocash.Application.Dto;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using System.Text.RegularExpressions;
using System.Web;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditMoneyBase : ComponentBase
    {
#nullable enable

        #region Declarations

        [Parameter]
        public MoneyDto? Money { get; set; }

        public Decimal Amount { get; set; }

        public bool IsDisabled
        {
            get
            {
                return Currency == null;
            }            
        }

        [Parameter]
        public CurrencyDto? Currency { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public EventCallback<MoneyDto> MoneyChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title += " is required";
            }
        }

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayCurrencySymbol
        {
            get
            {
                if (Currency != null
                    && !String.IsNullOrWhiteSpace(Currency.Id))
                {
                    return Currency.Id;
                }

                return string.Empty;
            }
        }

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            if (Money != null)
            {
                Amount = Money.Amount;
            }
        }

        protected async Task OnMoneyChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Decimal parsedDouble;
                Decimal.TryParse(newValue, out parsedDouble);

                Amount = parsedDouble;
            }
            else
            {
                Amount = 0;
            }

            CurrencyCode TempCurrencyCode;
            if (Currency != null 
                && !string.IsNullOrWhiteSpace(Currency.Id)
                && Enum.TryParse(Currency.Id, out TempCurrencyCode)
                && (Enum.IsDefined(typeof(CurrencyCode), TempCurrencyCode)))
            {
                Money = new MoneyDto(Amount, TempCurrencyCode);

                await MoneyChanged.InvokeAsync(Money);
            }            
        }
    }
}
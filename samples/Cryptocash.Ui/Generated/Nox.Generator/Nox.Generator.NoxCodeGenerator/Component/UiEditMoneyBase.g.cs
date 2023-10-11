using Cryptocash.Application.Dto;
using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditMoneyBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public MoneyDto Money { get; set; }

        public Decimal Amount { get; set; }

        public Nox.Types.CurrencyCode CurrencyCode { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<MoneyDto> MoneyChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title += " is required";
            }
        }

        #endregion

        protected override void OnInitialized()
        {
            if (Money != null)
            {
                Amount = Money.Amount;
                CurrencyCode = Money.CurrencyCode;
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
            
            Money = new MoneyDto(Amount, CurrencyCode);

            await MoneyChanged.InvokeAsync(Money);
        }
    }
}
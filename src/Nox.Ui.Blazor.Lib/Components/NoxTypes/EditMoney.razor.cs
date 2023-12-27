using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public class UiEditMoney : ComponentBase
{

    #region Declarations

    [Parameter]
    public MoneyModel? Money { get; set; }

    public decimal Amount { get; set; }

    public bool IsDisabled
    {
        get
        {
            return Currency == null;
        }            
    }

    [Parameter]
    public CurrencyCode? Currency { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<MoneyModel> MoneyChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return Title + " is required";
        }
    }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayCurrencySymbol
    {
        get
        {
            if (Currency != null)
            {
                string? rtnCurrencyStr = Currency.ToString();

                return rtnCurrencyStr!;
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
            _ = decimal.TryParse(newValue, out decimal parsedDouble);

            Amount = parsedDouble;
        }
        else
        {
            Amount = 0;
        }

        if (Currency != null)
        {
            Money = new MoneyModel()
            {
                Amount = Amount,
                CurrencyCode = (CurrencyCode)Currency
            };

            await MoneyChanged.InvokeAsync(Money);
        }            
    }
}
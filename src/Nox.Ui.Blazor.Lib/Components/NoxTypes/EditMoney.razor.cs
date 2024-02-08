using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditMoney : ComponentBase
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
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
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

    [Parameter]
    public MoneyTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public decimal MinValue { get; set; } = 0;

    [Parameter]
    public decimal MaxValue { get; set; } = 100;

    [Parameter]
    public int DecimalDigits { get; set; } = 100;

    [Parameter]
    public CurrencyCode DefaultCurrency { get; set; }

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
            DecimalDigits = TypeOptions.DecimalDigits;
            DefaultCurrency = TypeOptions.DefaultCurrency;
        }

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
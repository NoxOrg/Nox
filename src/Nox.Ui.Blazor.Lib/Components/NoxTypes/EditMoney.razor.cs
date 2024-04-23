using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditMoney : ComponentBase
{

    #region Declarations

    [Parameter]
    public MoneyModel Money { get; set; } = new();

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    [Parameter]
    public bool HideSpinButtons { get; set; } = true;

    [Parameter]
    public string? TitleCurrencyCode { get; set; } = Resources.Resources.TitleCurrencyCode;

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

    [Parameter]
    public List<CurrencyCode> CurrencyCodes { get; set; } = Enum.GetValues(typeof(CurrencyCode)).Cast<CurrencyCode>().ToList();

    [Parameter]
    public MoneyTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public decimal MinValue { get; set; }

    [Parameter]
    public decimal MaxValue { get; set; }

    [Parameter]
    public int DecimalDigits { get; set; }

    [Parameter]
    public CurrencyCode DefaultCurrency { get; set; }

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        TypeOptions ??= new();
        MinValue = TypeOptions.MinValue;
        MaxValue = TypeOptions.MaxValue;
        DecimalDigits = TypeOptions.DecimalDigits;
        DefaultCurrency = TypeOptions.DefaultCurrency;

        Money ??= new() { CurrencyCode = DefaultCurrency };
    }

    private async Task OnAmountChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedValue))
        {
            Money.Amount = parsedValue;
        }

        await MoneyChanged.InvokeAsync(Money);
    }

    private async Task OnCurrencyCodeChanged(string newValue)
    {
        if (Enum.TryParse(newValue, out CurrencyCode currency))
        {

            Money.CurrencyCode = currency;
        }

        await MoneyChanged.InvokeAsync(Money);
    }
}
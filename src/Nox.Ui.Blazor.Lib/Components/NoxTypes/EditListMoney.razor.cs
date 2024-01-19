using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditListMoney : ComponentBase
{

    #region Declarations

    [Parameter]
    public MoneyModel? CurrentMoney { get; set; }

    [Parameter]
    public string? TitleCurrency { get; set; }

    [Parameter]
    public string? TitleAmount { get; set; }

    public bool IsLoading { get; set; } = false;

    [Parameter]
    public List<MoneyModel> MoneyList { get; set; } = new();

    [Parameter]
    public List<CurrencyModel> CurrencySelectionList { get; set; } = new();

    [Parameter]
    public EventCallback<List<MoneyModel>> MoneyListListChanged { get; set; }

    public string? CurrentCurrencyIdStr { get; set; }

    public string? CurrentAmountStr { get; set; }

    public decimal Amount { get; set; } = 0;

    public CurrencyModel? CurrentCurrency { get; set; }

    public MudForm? AddMinimumCashStockEntityForm { get; set; }

    public bool AddMinimumCashStockValidateSuccess { get; set; } = false;

    [Parameter]
    public string Format { get; set; } = "#.##";

    public bool IsDisabled
    {
        get
        {
            return CurrentCurrency == null;
        }
    }

    public string DisplayCurrencySymbol
    {
        get
        {
            if (CurrentCurrency != null
                && !String.IsNullOrWhiteSpace(CurrentCurrency.Id))
            {
                return CurrentCurrency.Id;
            }

            return string.Empty;
        }
    }

    #endregion

    protected void OnCurrencyIdChanged(string newValue)
    {
        CurrentCurrencyIdStr = newValue;

        if (!String.IsNullOrWhiteSpace(CurrentCurrencyIdStr)
            && CurrencySelectionList != null)
        {
            CurrentCurrency = CurrencySelectionList.Find(Currency => String.Equals(Currency.Id, CurrentCurrencyIdStr, StringComparison.CurrentCultureIgnoreCase));
        }

        if (CurrentCurrency != null
            && !string.IsNullOrWhiteSpace(CurrentCurrency.Id)
            && Enum.TryParse(CurrentCurrency.Id, out CurrencyCode TempCurrencyCode)
            && (Enum.IsDefined(typeof(CurrencyCode), TempCurrencyCode)))
        {
            CurrentMoney = new()
            {
                Amount = Amount,
                CurrencyCode = TempCurrencyCode
            };
        }
        else
        {
            CurrentMoney = null;
        }
    }

    protected void OnAmountChanged(string newValue)
    {
        CurrentAmountStr = newValue;

        if (!string.IsNullOrWhiteSpace(CurrentAmountStr)
            && decimal.TryParse(CurrentAmountStr, out decimal parsedDecimal))
        {
            Amount = parsedDecimal;
        }
        else
        {
            Amount = 0;
        }

        if (CurrentCurrency != null
            && !string.IsNullOrWhiteSpace(CurrentCurrency.Id)
            && Enum.TryParse(CurrentCurrency.Id, out CurrencyCode TempCurrencyCode)
            && (Enum.IsDefined(typeof(CurrencyCode), TempCurrencyCode)))
        {
            CurrentMoney = new()
            {
                Amount = Amount,
                CurrencyCode = TempCurrencyCode
            };
        }
        else
        {
            CurrentMoney = null;
        }
    }

    protected async Task AddItem()
    {
        if (CurrentMoney != null)
        {
            if (MoneyList != null)
            {
                MoneyList.RemoveAll(CashStock => CashStock.CurrencyCode == CurrentMoney.CurrencyCode);
            }
            else
            {
                MoneyList = new();
            }

            MoneyList.Add(CurrentMoney);
            await MoneyListListChanged.InvokeAsync(MoneyList);
            ResetAdd();
        }
    }

    protected void ResetAdd()
    {
        CurrentMoney = null;
        Amount = 0;
        CurrentCurrencyIdStr = null;
        CurrentAmountStr = null;
        CurrentCurrency = null;
    }

    protected async Task RemoveItem(MoneyModel CurrentItem)
    {
        IsLoading = true;

        if (MoneyList.Any())
        {
            MoneyList.Remove(CurrentItem);
            await MoneyListListChanged.InvokeAsync(MoneyList);
        }        

        IsLoading = false;
    }

    protected static string ErrorRequiredMessage(string? CurrentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, CurrentTitle);
    }
}
using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;
using static MongoDB.Driver.WriteConcern;
using System.Web;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditEntityCreateMinimumCashStockBase : ComponentBase
    {
        #nullable enable

        #region Declarations

        [Parameter]
        public MinimumCashStockCreateDto? CurrentMinimumCashStock { get; set; }

        [Parameter]
        public string TitleCurrency { get; set; } = string.Empty;

        [Parameter]
        public string TitleAmount { get; set; } = string.Empty;

        [Parameter]
        public List<MinimumCashStockCreateDto>? MinimumCashStockList { get; set; } = null;

        [Parameter]
        public List<CurrencyDto> CurrencySelectionList { get; set; } = new();

        [Parameter]
        public EventCallback<List<MinimumCashStockCreateDto>> MinimumCashStockListChanged { get; set; }

        public string? CurrentCurrencyIdStr { get; set; }

        public string? CurrentAmountStr { get; set; }

        public Decimal Amount { get; set; } = 0;

        public CurrencyDto? CurrentCurrency { get; set; }

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
                 CurrentCurrency = CurrencySelectionList.FirstOrDefault(Currency => String.Equals(Currency.Id, CurrentCurrencyIdStr, StringComparison.CurrentCultureIgnoreCase));
            }

            CurrencyCode TempCurrencyCode;
            if (CurrentCurrency != null
                && !string.IsNullOrWhiteSpace(CurrentCurrency.Id)
                && Enum.TryParse(CurrentCurrency.Id, out TempCurrencyCode) 
                && (Enum.IsDefined(typeof(CurrencyCode), TempCurrencyCode)))
            {                
                CurrentMinimumCashStock = new();
                CurrentMinimumCashStock.Amount = new(Amount, (CurrencyCode)TempCurrencyCode);
            }
            else
            {
                CurrentMinimumCashStock = null;
            }
        }

        protected void OnAmountChanged(string newValue)
        {
            CurrentAmountStr = newValue;

            if (!string.IsNullOrWhiteSpace(CurrentAmountStr))
            {
                Decimal parsedDouble;
                Decimal.TryParse(CurrentAmountStr, out parsedDouble);

                Amount = parsedDouble;
            }
            else
            {
                Amount = 0;
            }

            CurrencyCode TempCurrencyCode;
            if (CurrentCurrency != null
                && !string.IsNullOrWhiteSpace(CurrentCurrency.Id)
                && Enum.TryParse(CurrentCurrency.Id, out TempCurrencyCode)
                && (Enum.IsDefined(typeof(CurrencyCode), TempCurrencyCode)))
            {
                CurrentMinimumCashStock = new();
                CurrentMinimumCashStock.Amount = new(Amount, (CurrencyCode)TempCurrencyCode);
            }
            else
            {
                CurrentMinimumCashStock = null;
            }            
        }

        protected async Task AddItem()
        {
            if (CurrentMinimumCashStock != null)
            {
                if (MinimumCashStockList != null)
                {
                    MinimumCashStockList.RemoveAll(CashStock => CashStock.Amount.CurrencyCode.Equals(CurrentMinimumCashStock.Amount.CurrencyCode));
                }
                else
                {
                    MinimumCashStockList = new();
                }

                MinimumCashStockList.Add(CurrentMinimumCashStock);
                await MinimumCashStockListChanged.InvokeAsync(MinimumCashStockList);
                ResetAdd();
            }             
        }

        protected void ResetAdd()
        {
            CurrentMinimumCashStock = null;
            Amount = 0;
            CurrentCurrencyIdStr = null;
            CurrentAmountStr = null;
            CurrentCurrency = null;
        }
    }
}
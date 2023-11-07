using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditEntityListMinimumCashStockBase : ComponentBase
    {
        #region Declarations

        public bool IsLoading = false;

        [Parameter]
        public string TitleCurrency { get; set; }

        [Parameter]
        public string TitleAmount { get; set; }

        [Parameter]
        public List<MinimumCashStockCreateDto> MinimumCashStockList { get; set; } = null;

        [Parameter]
        public EventCallback<List<MinimumCashStockCreateDto>> MinimumCashStockListChanged { get; set; }

        #endregion

        protected async Task RemoveItem(MinimumCashStockCreateDto CurrentItem)
        {
            IsLoading = true;

            MinimumCashStockList.Remove(CurrentItem);
            await MinimumCashStockListChanged.InvokeAsync(MinimumCashStockList);

            IsLoading = false;
        }

        protected string ErrorRequiredMessage(string CurrentTitle)
        {
            return CurrentTitle + " is required";
        }
    }
}
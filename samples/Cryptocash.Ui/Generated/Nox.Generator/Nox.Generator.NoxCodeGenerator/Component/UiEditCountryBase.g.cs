using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditCountryBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public CountryDto Country { get; set; }

        [Parameter]
        public string CountryId { get; set; }

        public string CurrentCountryIdStr { get; set; }

        [Parameter]
        public string TitleCountry { get; set; }

        [Parameter]
        public List<CountryDto> CountrySelectionList { get; set; } = null;

        [Parameter]
        public EventCallback<CountryDto> CountryChanged { get; set; }

        [Parameter]
        public EventCallback<string> CountryIdChanged { get; set; }

        #endregion

        protected async Task OnCountryIdChanged(string newValue)
        {
            CurrentCountryIdStr = newValue;

            Country = CountrySelectionList.FirstOrDefault(Country => string.Equals(Country.Id, CurrentCountryIdStr, StringComparison.OrdinalIgnoreCase));
            await CountryChanged.InvokeAsync(Country);

            if (Country != null
                && !String.IsNullOrWhiteSpace(Country.Id))
            {
                CountryId = Country.Id;
                await CountryIdChanged.InvokeAsync(CountryId);
            }            
        }

        protected string ErrorRequiredMessage(string CurrentTitle)
        {
            return CurrentTitle += " is required";
        }
    }
}
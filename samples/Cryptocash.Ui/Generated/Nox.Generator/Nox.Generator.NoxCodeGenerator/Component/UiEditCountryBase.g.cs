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
        public CountryCreateDto CountryCreate { get; set; }

        public string CurrentCountryIdStr { get; set; }

        private Nox.Types.CountryCode? _CurrentCountryId { get; set; }

        public Nox.Types.CountryCode? CurrentCountryId { 
            get
            {
                if (_CurrentCountryId != null)
                {
                    return _CurrentCountryId;
                }

                if (!String.IsNullOrWhiteSpace(CurrentCountryIdStr)
                    && Enum.IsDefined(typeof(Nox.Types.CountryCode), CurrentCountryIdStr))
                {
                    return (Nox.Types.CountryCode?)Enum.Parse(typeof(Nox.Types.CountryCode), CurrentCountryIdStr);
                }
                else{
                    return null;
                }
            } 
            
            set { _CurrentCountryId = value; }
         }

        [Parameter]
        public string TitleCountry { get; set; }

        [Parameter]
        public List<CountryDto> CountrySelectionList { get; set; } = null;

        [Parameter]
        public EventCallback<CountryDto> CountryChanged { get; set; }

        [Parameter]
        public EventCallback<CountryCreateDto> CountryCreateChanged { get; set; }

        #endregion

        protected async Task OnCountryIdChanged(string newValue)
        {
            CurrentCountryIdStr = newValue;

            Country = CountrySelectionList.FirstOrDefault(Country => string.Equals(Country.Id, CurrentCountryIdStr, StringComparison.OrdinalIgnoreCase));
            await CountryChanged.InvokeAsync(Country);

            CountryCreate = CountryService.ConvertCountryIntoCreateDto(Country);            
            await CountryCreateChanged.InvokeAsync(CountryCreate);
        }

        protected string ErrorRequiredMessage(string CurrentTitle)
        {
            return CurrentTitle += " is required";
        }
    }
}
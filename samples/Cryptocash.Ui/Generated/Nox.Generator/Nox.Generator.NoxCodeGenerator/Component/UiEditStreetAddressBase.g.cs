using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditStreetAddressBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public StreetAddressDto StreetAddress { get; set; }

        public string CurrentStreetNumber { get; set; }

        public string CurrentAddressLine1 { get; set; }

        public string CurrentAddressLine2 { get; set; }

        public string CurrentRoute { get; set; }

        public string CurrentLocality { get; set; }

        public string CurrentNeighborhood { get; set; }

        public string CurrentAdministrativeArea1 { get; set; }

        public string CurrentAdministrativeArea2 { get; set; }

        public string CurrentPostalCode { get; set; }

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
        public string TitleStreetNumber { get; set; }

        [Parameter]
        public string TitleAddressLine1 { get; set; }

        [Parameter]
        public string TitleAddressLine2 { get; set; }

        [Parameter]
        public string TitleRoute { get; set; }

        [Parameter]
        public string TitleLocality { get; set; }

        [Parameter]
        public string TitleNeighborhood { get; set; }

        [Parameter]
        public string TitleAdministrativeArea1 { get; set; }

        [Parameter]
        public string TitleAdministrativeArea2 { get; set; }

        [Parameter]
        public string TitlePostalCode { get; set; }

        [Parameter]
        public string TitleCountryId { get; set; }

        [Parameter]
        public List<CountryDto> CountrySelectionList { get; set; } = null;

        [Parameter]
        public EventCallback<StreetAddressDto> StreetAddressChanged { get; set; }

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            if (StreetAddress != null)
            {
                CurrentStreetNumber = StreetAddress.StreetNumber;
                CurrentAddressLine1 = StreetAddress.AddressLine1;
                CurrentAddressLine2 = StreetAddress.AddressLine2;
                CurrentRoute = StreetAddress.Route;
                CurrentLocality = StreetAddress.Locality; 
                CurrentNeighborhood = StreetAddress.Neighborhood;
                CurrentAdministrativeArea1 = StreetAddress.AdministrativeArea1;
                CurrentAdministrativeArea2 = StreetAddress.AdministrativeArea2;
                CurrentPostalCode = StreetAddress.PostalCode;
                CurrentCountryIdStr = StreetAddress.CountryId.ToString();
            }
        }

        protected async Task OnStreetNumberChanged(string newValue)
        {
            CurrentStreetNumber = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnAddressLine1Changed(string newValue)
        {
            CurrentAddressLine1 = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnAddressLine2Changed(string newValue)
        {
            CurrentAddressLine2 = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnRouteChanged(string newValue)
        {
            CurrentRoute = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnLocalityChanged(string newValue)
        {
            CurrentLocality = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnNeighborhoodChanged(string newValue)
        {
            CurrentNeighborhood = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnAdministrativeArea1Changed(string newValue)
        {
            CurrentAdministrativeArea1 = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnAdministrativeArea2Changed(string newValue)
        {
            CurrentAdministrativeArea2 = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnPostalCodeChanged(string newValue)
        {
            CurrentPostalCode = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);
        }

        protected async Task OnCountryIdChanged(string newValue)
        {
            CurrentCountryIdStr = newValue;

            RefreshStreetAddress();

            await StreetAddressChanged.InvokeAsync(StreetAddress);    
        }

        private void RefreshStreetAddress()
        {
            if (CurrentCountryId != null)
            {
                StreetAddress = new StreetAddressDto(
                CurrentStreetNumber,
                CurrentAddressLine1,
                CurrentAddressLine2,
                CurrentRoute,
                CurrentLocality,
                CurrentNeighborhood,
                CurrentAdministrativeArea1,
                CurrentAdministrativeArea2,
                CurrentPostalCode,
                (Nox.Types.CountryCode)CurrentCountryId
                );
            }            
        }

        protected string ErrorRequiredMessage(string CurrentTitle)
        {
            return CurrentTitle += " is required".Trim();
        }
    }
}
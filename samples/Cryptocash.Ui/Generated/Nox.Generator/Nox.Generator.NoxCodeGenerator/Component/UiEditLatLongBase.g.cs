using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using MudBlazor;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditLatLongBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public LatLongDto LatLong { get; set; }

        public double? CurrentLatitude { get; set; }

        public double? CurrentLongitude { get; set; }

        [Parameter]
        public string TitleLatitude { get; set; }

        [Parameter]
        public string TitleLongitude { get; set; }

        [Parameter]
        public EventCallback<LatLongDto> LatLongChanged { get; set; }

        [Parameter]
        public string Format { get; set; } = "#.########";

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            if (LatLong != null)
            {
                CurrentLatitude = LatLong.Latitude;
                CurrentLongitude = LatLong.Longitude;
            }
        }

        protected async Task OnLatitudeChanged(string newValue)
        {
            double parsedDouble;
            double.TryParse(newValue, out parsedDouble);

            CurrentLatitude = parsedDouble;

            double useLongitude = 0;
            if (CurrentLongitude != null)
            {
                useLongitude = (double)CurrentLongitude;
            }

            LatLong = new LatLongDto((double)CurrentLatitude, useLongitude);

            await LatLongChanged.InvokeAsync(LatLong);
        }

        protected async Task OnLongitudeChanged(string newValue)
        {
            double parsedDouble;
            double.TryParse(newValue, out parsedDouble);

            CurrentLongitude = parsedDouble;

            double useLatitude = 0;
            if (CurrentLatitude != null)
            {
                useLatitude = (double)CurrentLatitude;
            }

            LatLong = new LatLongDto(useLatitude, (double)CurrentLongitude);

            await LatLongChanged.InvokeAsync(LatLong);
        }

        protected string ErrorRequiredMessage(string CurrentTitle)
        {
            return CurrentTitle += " is required";
        }
    }
}
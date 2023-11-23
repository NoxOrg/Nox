using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;
using System.Globalization;
using System;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiEditDateBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public System.DateTime? Date { get; set; }       

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string Format { get; set; } = "dd/MM/yyyy";

        [Parameter]
        public EventCallback<System.DateTime?> DateChanged { get; set; }

        #endregion

        protected async Task OnDateChanged(string newValue)
        {
            System.DateTime CurrentDate;

            if (!string.IsNullOrWhiteSpace(newValue)
                && System.DateTime.TryParse(newValue, out CurrentDate))
            {
                Date = CurrentDate;
                await DateChanged.InvokeAsync(Date);
            }
            else
            {
                Date = null;
                await DateChanged.InvokeAsync(Date);
            }         
        }        

        protected string ErrorRequiredMessage(string? CurrentTitle)
        {
            return CurrentTitle + " is required";
        }

        public string DisplayPlaceholder
        {
            get
            {
                return Format.ToUpper();
            }
        }
    }
}
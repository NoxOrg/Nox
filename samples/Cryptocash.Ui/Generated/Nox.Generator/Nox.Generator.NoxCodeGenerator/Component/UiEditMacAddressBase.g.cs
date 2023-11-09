﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditMacAddressBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public string MacAddress { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<string> MacAddressChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title + " is required";
            }
        }

        [Parameter]
        public string Format { get; set; } = "##:##:##:##:##:##";

        #endregion

        protected async Task OnMacAddressChanged(string newValue)
        {
            MacAddress = newValue;

            await MacAddressChanged.InvokeAsync(MacAddress);
        }

        public IMask DisplayMask()
        {
            return new PatternMask(Format)
            {
                MaskChars = new[] { new MaskChar('#', @"[0-9a-fA-F]") },
                CleanDelimiters = true,
                Transformation = AllUpperCase
            };
        }

        private static char AllUpperCase(char c) => c.ToString().ToUpperInvariant()[0];
    }
}
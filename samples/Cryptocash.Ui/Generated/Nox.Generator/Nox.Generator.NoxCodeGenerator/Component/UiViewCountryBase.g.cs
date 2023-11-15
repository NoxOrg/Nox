using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Nox.Types;
using Microsoft.SqlServer.Server;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewCountryBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public CountryDto Country { get; set; }

        public string DisplayCountryName
        {

            get
            {
                if (Country != null
                    && !String.IsNullOrWhiteSpace(Country.Name))
                {
                    return Country.Name;
                }

                return String.Empty;
            }
        }

        #endregion
    }
}
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewDateTimeBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public DateTime? DateTime { get; set; }

        [Parameter]
        public string Format { get; set; } = "dd/MM/yyyy HH:mm:ss";

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        #endregion
    }
}
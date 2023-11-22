using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewDateBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public DateTime? Date { get; set; }

        [Parameter]
        public string Format { get; set; } = "dd/MM/yyyy";

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        #endregion
    }
}
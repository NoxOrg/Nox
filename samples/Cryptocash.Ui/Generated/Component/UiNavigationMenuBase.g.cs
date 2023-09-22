using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Generated.Data.Helper;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiNavigationMenuBase : ComponentBase
    {
        #region Declarations

        public string EmployeesIcon { get; set; } = IconHelper.GetIconSvgPath("Employees");
        public string EmployeesPageLink { get; set; } = "Employees";

        public string CustomersIcon { get; set; } = IconHelper.GetIconSvgPath("Customers");
        public string CustomersPageLink { get; set; } = "Customers";

        public string VendingMachinesIcon { get; set; } = IconHelper.GetIconSvgPath("VendingMachines");
        public string VendingMachinesPageLink { get; set; } = "VendingMachines";

        #endregion
    }
}
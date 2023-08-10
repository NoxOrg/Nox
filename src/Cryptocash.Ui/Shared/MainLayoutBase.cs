using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Data;

namespace Cryptocash.Ui
{
    public class MainLayoutBase : LayoutComponentBase
    {
        #region Declarations

        /// <summary>
        /// Property DrawerOpen used to handle drawer display
        /// </summary>
        public bool DrawerOpen = true;

        /// <summary>
        /// Property GlobalData used to handle global data between parent and child components
        /// </summary>
        public GlobalData GlobalData = new()
        {
            ApiDefinitions = new()
        };

        #endregion

        #region Main Page Functions

        /// <summary>
        /// Initialise method to initally setup page and default data
        /// </summary>
        /// <returns></returns>
        protected override void OnInitialized()
        {
            //just preset for now but should in future get Apis from YAML config
            GlobalData.ApiDefinitions!.Add(new() {
                Name = "Exchange Bookings",
                PageLink = "Bookings",
                Icon = "<path d=\"M12.89,11.1c-1.78-0.59-2.64-0.96-2.64-1.9c0-1.02,1.11-1.39,1.81-1.39c1.31,0,1.79,0.99,1.9,1.34l1.58-0.67 C15.39,8.03,14.72,6.56,13,6.24V5h-2v1.26C8.52,6.82,8.51,9.12,8.51,9.22c0,2.27,2.25,2.91,3.35,3.31 c1.58,0.56,2.28,1.07,2.28,2.03c0,1.13-1.05,1.61-1.98,1.61c-1.82,0-2.34-1.87-2.4-2.09L8.1,14.75c0.63,2.19,2.28,2.78,2.9,2.96V19 h2v-1.24c0.4-0.09,2.9-0.59,2.9-3.22C15.9,13.15,15.29,11.93,12.89,11.1z M3,21H1v-6h6v2l-2.48,0c1.61,2.41,4.36,4,7.48,4 c4.97,0,9-4.03,9-9h2c0,6.08-4.92,11-11,11c-3.72,0-7.01-1.85-9-4.67L3,21z M1,12C1,5.92,5.92,1,12,1c3.72,0,7.01,1.85,9,4.67L21,3 h2v6h-6V7l2.48,0C17.87,4.59,15.12,3,12,3c-4.97,0-9,4.03-9,9H1z\"/>",                
                IsDefault = true
            });
            GlobalData.ApiDefinitions!.Add(new()
            {
                Name = "Vending Machines",
                PageLink = "VendingMachines",
                Icon = "<path d=\"M17,11V3H7v4H3v14h8v-4h2v4h8V11H17z M7,19H5v-2h2V19z M7,15H5v-2h2V15z M7,11H5V9h2V11z M11,15H9v-2h2V15z M11,11H9V9h2 V11z M11,7H9V5h2V7z M15,15h-2v-2h2V15z M15,11h-2V9h2V11z M15,7h-2V5h2V7z M19,19h-2v-2h2V19z M19,15h-2v-2h2V15z\"/>"                
            });
        }

        /// <summary>
        /// Method to handle drawer display
        /// </summary>
        public void ToggleDrawer()
        {
            DrawerOpen = !DrawerOpen;
        }

        #endregion
    }
}
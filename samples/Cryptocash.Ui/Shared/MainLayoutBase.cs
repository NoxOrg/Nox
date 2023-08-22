using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Generated.Data;

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
                Name = "Customers",
                PageLink = "Customer",
                Icon = "<path d=\"M14,7h-4C8.9,7,8,7.9,8,9v6h2v7h4v-7h2V9C16,7.9,15.1,7,14,7z\"/><circle cx=\"12\" cy=\"4\" r=\"2\"/>",                
                IsDefault = true
            });
            GlobalData.ApiDefinitions!.Add(new()
            {
                Name = "Employees",
                PageLink = "Employee",
                Icon = "<path d=\"M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z\"/>"
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
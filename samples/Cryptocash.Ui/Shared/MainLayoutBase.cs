using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Generated;
using Cryptocash.Ui.Generated.Data.Generic;

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
        public GlobalData GlobalData = new();

        #endregion

        #region Main Page Functions

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
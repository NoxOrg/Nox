using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Data.Helper
{
    /// <summary>
    /// Navigation helper class to enable easy to redirect to another internal blazor page
    /// </summary>
    public class NavigationHelper
    {
        private readonly NavigationManager _navigationManager;
        public NavigationHelper(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// Method to handle page redirect
        /// </summary>
        /// <param name="Url"></param>
        public void ChangePage(string Url)
        {
            _navigationManager.NavigateTo(Url);
        }
    }

}
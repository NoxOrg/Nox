using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Generated.Data;

namespace Cryptocash.Ui.Generated.Pages.Generic
{
    /// <summary>
    /// PageBase Class to handle List Entity related pages note: T is used to reduce the amount of generator code required
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListEntityPageBase<T> : ComponentBase
    {
        #region Declarations

        /// <summary>
        /// Property GlobalData used to handle global data between parent and child components
        /// </summary>
        [CascadingParameter]
        public GlobalData? GlobalData { get; set; }

        /// <summary>
        /// Property IsLoading used to handle Ui main loading panel
        /// </summary>
        public bool IsLoading = false;

        /// <summary>
        /// Property CurrentEntityName used to define which Api currently displaying
        /// </summary>
        public string CurrentEntityName = typeof(T).Name[..^6]; //remove word 'Entity' from end

        #endregion

        #region Main Page Functions

        /// <summary>
        /// Initialise method to initally setup page and default data
        /// </summary>
        /// <returns></returns>
        protected override void OnInitialized()
        {
            UpdateHeaderApiName();
        }

        /// <summary>
        /// Method to update the current Api definition globally in this case to change the header title to current Api name
        /// </summary>
        private void UpdateHeaderApiName()
        {
            if (GlobalData != null
                && GlobalData!.ApiDefinitions != null)
            {
                ApiDefinition? CurrentApiDefinition = GlobalData!.ApiDefinitions!
                    .FirstOrDefault(ApiDefinition => ApiDefinition.PageLink!.Equals(CurrentEntityName, StringComparison.OrdinalIgnoreCase));

                if (CurrentApiDefinition != null)
                {
                    GlobalData.CurrentApiDefinition = CurrentApiDefinition;
                    GlobalData.ValuesChanged?.Invoke();
                }
            }
        }

        #endregion
    }
}
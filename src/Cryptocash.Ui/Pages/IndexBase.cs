using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Data.Helper;
using Cryptocash.Ui.Data;

namespace Cryptocash.Ui.Pages
{
    public class IndexBase : ComponentBase
    {
        #region Declarations

        /// <summary>
        /// Use to reference and display global data based on current Api being used
        /// </summary>
        [CascadingParameter]
        public GlobalData? GlobalData { get; set; }

        /// <summary>
        /// Property NavigationHelper used to aid page redirections
        /// </summary>
        [Inject]
        NavigationHelper? NavigationHelper { get; set; }

        #endregion

        protected override void OnInitialized()
        {
            CheckInitialDefaultAndRedirect();
        }

        /// <summary>
        /// Method to redirect page to default Api definition on the first page load
        /// </summary>
        private void CheckInitialDefaultAndRedirect()
        {
            if (GlobalData != null
                && GlobalData!.ApiDefinitions != null
                && GlobalData!.CurrentApiDefinition == null)
            {
                GlobalData!.CurrentApiDefinition = GlobalData!.ApiDefinitions!.FirstOrDefault(ApiDefinition => ApiDefinition.IsDefault);

                if (GlobalData!.CurrentApiDefinition != null
                    && !String.IsNullOrWhiteSpace(GlobalData!.CurrentApiDefinition.PageLink))
                {
                    NavigationHelper?.ChangePage(GlobalData!.CurrentApiDefinition!.PageLink!);
                }
            }
        }
    }
}
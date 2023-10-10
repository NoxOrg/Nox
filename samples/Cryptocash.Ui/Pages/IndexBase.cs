using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Generated.Data.Helper;
using Cryptocash.Ui.Generated;
using Cryptocash.Ui.Generated.Data.Generic;

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
                && GlobalData?.CurrentDomainEntity == null)
            {

                if (!String.IsNullOrWhiteSpace(GlobalData?.CurrentDomainEntity))
                {
                    NavigationHelper?.ChangePage(GlobalData?.CurrentDomainEntity!);
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(GlobalData?.DefaultDomainEntity))
                    {
                        GlobalData!.CurrentDomainEntity = GlobalData?.DefaultDomainEntity!;
                        NavigationHelper?.ChangePage(GlobalData?.DefaultDomainEntity!);
                    }
                }
            }
        }
    }
}
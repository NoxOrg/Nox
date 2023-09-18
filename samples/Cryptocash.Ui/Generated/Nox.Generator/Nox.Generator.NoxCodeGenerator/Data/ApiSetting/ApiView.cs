using Cryptocash.Ui.Generated.Data.Enum;

namespace Cryptocash.Ui.Generated.Data.ApiSetting
{
    /// <summary>
    /// Setting class to define column view options used on returned result entities from target Api in the Ui
    /// </summary>
    public class ApiView
    {
        private ApiViewType? _currentView = null;

        private ApiViewType? _setView = null;

        /// <summary>
        /// Property PropertyName used to associate View with a PropertyName in result entity
        /// </summary>
        public string? PropertyName { get; set; }

        /// <summary>
        /// Property DefaultView used as a default column display setting for this View when resetting back to default settings on Ui
        /// </summary>
        public ApiViewType DefaultView { get; set; }

        /// <summary>
        /// Property CurrentView used as a current column display setting for this View on Ui
        /// </summary>
        public ApiViewType CurrentView {
            get
            {
                _currentView ??= DefaultView;
                return (ApiViewType)_currentView;
            }
            set
            {
                _currentView = value;
            }
        }

        /// <summary>
        /// Property SetView used as a temporary column display setting when user manually amending View settings in Ui before applying them
        /// </summary>
        public ApiViewType SetView
        {
            get
            {
                _setView ??= CurrentView;
                return (ApiViewType)_setView;
            }
            set
            {
                _setView = value;
            }
        }

        /// <summary>
        /// Property ViewOptionList used as a collection of available display settings for this View in this case hidden or displayed
        /// </summary>
        public List<ApiViewType>? ViewOptionList { get; set; }

        /// <summary>
        /// Property IsSetViewDisabled used to decide in Ui if View can be manually set or not
        /// </summary>
        public bool IsSetViewDisabled { 
            get {

                if (ViewOptionList != null)
                {
                    return !ViewOptionList.Contains(ApiViewType.Displayed)
                           || !ViewOptionList.Contains(ApiViewType.Hidden);
                }

                return true;               
            } 
        }

        /// <summary>
        /// Method to reset current and set View to default display settings
        /// </summary>
        public void ResetView()
        {
            _currentView = null;
            _setView = null;
        }

        /// <summary>
        /// Method to update the View to new value
        /// </summary>
        /// <param name="UpdateType"></param>
        public void UpdateSetView(ApiViewType UpdateType)
        {
            SetView = UpdateType;
        }
    }
}
using Cryptocash.Ui.Generated.Data.Enum;

namespace Cryptocash.Ui.Generated.Data.ApiSetting
{
    /// <summary>
    /// Filter class to handle Search filters for Api search query
    /// </summary>
    public class ApiSearchFilter
    {
        private string? _currentSearchFilterValue = null;

        private string? _setSearchFilterValue = null;

        /// <summary>
        /// Property PropertyName used to associate Search filter with a PropertyName in result entity
        /// </summary>
        public string? PropertyName { get; set; }

        /// <summary>
        /// Property DefaultSearchFilterValue used as a default search value for this search filter when resetting back to default settings on Ui
        /// </summary>
        public string? DefaultSearchFilterValue { get; set; }

        /// <summary>
        /// Property CurrentSearchFilterValue used as a current search value for this search filter on Ui
        /// </summary>
        public string? CurrentSearchFilterValue
        {
            get
            {
                _currentSearchFilterValue ??= DefaultSearchFilterValue;
                return _currentSearchFilterValue;
            }
            set
            {
                _currentSearchFilterValue = value;
            }
        }

        /// <summary>
        /// Property SetSearchFilterValue used as a temporary search value for this search filter when user manually amends settings in Ui before applying them
        /// </summary>
        public string? SetSearchFilterValue
        {
            get
            {
                _setSearchFilterValue ??= CurrentSearchFilterValue;
                return _setSearchFilterValue;
            }
            set
            {
                _setSearchFilterValue = value;
            }
        }

        /// <summary>
        /// Property SearchValueOptionList used as a collection of available values for this search filter
        /// </summary>
        public List<string>? SearchValueOptionList { get; set; }

        /// <summary>
        /// Property SearchFilterType used as a search comparison type for this search filter
        /// </summary>
        public ApiSearchFilterType SearchFilterType { get; set; }

        /// <summary>
        /// Property SearchFilterLocation used to define where the search is used on the Ui
        /// </summary>
        public ApiSearchFilterLocation SearchFilterLocation { get; set; }

        /// <summary>
        /// Property IsDropdownSelection used to define is control should be a dropdown list
        /// </summary>
        public bool IsDropdownSelection { 
            get
            {
                return SearchValueOptionList != null && SearchValueOptionList.Count > 1;
            }
        }

        /// <summary>
        /// Method to reset current and set search filters to default settings
        /// </summary>
        public void ResetSearchFilter()
        {
            _currentSearchFilterValue = null;
            _setSearchFilterValue = null;
        }

        /// <summary>
        /// Method to update SetSearchFilterValue to new value
        /// </summary>
        /// <param name="UpdateValue"></param>
        public void UpdateSetSearchFilterValue(string UpdateValue)
        {
            _setSearchFilterValue = UpdateValue;
        }
    }
}
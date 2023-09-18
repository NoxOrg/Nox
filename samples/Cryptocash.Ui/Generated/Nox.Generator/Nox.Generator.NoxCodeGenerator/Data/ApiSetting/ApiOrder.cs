using Cryptocash.Ui.Generated.Data.Enum;

namespace Cryptocash.Ui.Generated.Data.ApiSetting
{
    /// <summary>
    /// Setting class to define column order options used on returned result entities from target Api in the Ui
    /// </summary>
    public class ApiOrder
    {
        private ApiOrderDirection? _currentOrderDirection = null;

        /// <summary>
        /// Property PropertyName used to associate column order with a PropertyName in result entity
        /// </summary>
        public string? PropertyName { get; set; }

        /// <summary>
        /// Property Ordertype used to define if ordering is applied to a column or not
        /// </summary>
        public ApiOrderType OrderType { get; set; }

        /// <summary>
        /// Property DefaultOrderDirection used as a default column order setting for this Order when resetting back to default settings on Ui
        /// </summary>
        public ApiOrderDirection DefaultOrderDirection { get; set; }

        /// <summary>
        /// Property CurrentOrderDirection used as a current column order setting for this Order on Ui
        /// </summary>
        public ApiOrderDirection CurrentOrderDirection
        {
            get
            {
                _currentOrderDirection ??= DefaultOrderDirection;
                return (ApiOrderDirection)_currentOrderDirection;
            }
            set
            {
                _currentOrderDirection = value;
            }
        }

        /// <summary>
        /// Method to reset column order to default display settings
        /// </summary>
        public void ResetOrderDirection()
        {
            _currentOrderDirection = null;
        }

        /// <summary>
        /// Method to update current column order to new setting
        /// </summary>
        public void UpdateCurrentOrderDirection(ApiOrderDirection UpdateDirection)
        {
            _currentOrderDirection = UpdateDirection;
        }
    }
}
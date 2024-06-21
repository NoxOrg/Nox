using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Data;

/// <summary>
/// Setting class to define column order options used on returned result entities from target Api in the Ui
/// </summary>
public class SortOrder
{
    #nullable enable

    private SortOrderDirection? _currentOrderDirection = null;

    /// <summary>
    /// Property PropertyName used to associate column order with a PropertyName in result entity
    /// </summary>
    public string? PropertyName { get; set; }

    /// <summary>
    /// Property Ordertype used to define if ordering is applied to a column or not
    /// </summary>
    public bool CanSort { get; set; }

    /// <summary>
    /// Property DefaultOrderDirection used as a default column order setting for this Order when resetting back to default settings on Ui
    /// </summary>
    public SortOrderDirection DefaultOrderDirection { get; set; }

    /// <summary>
    /// Property CurrentOrderDirection used as a current column order setting for this Order on Ui
    /// </summary>
    public SortOrderDirection CurrentOrderDirection
    {
        get
        {
            _currentOrderDirection ??= DefaultOrderDirection;
            return (SortOrderDirection)_currentOrderDirection;
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
    public void UpdateCurrentOrderDirection(SortOrderDirection UpdateDirection)
    {
        _currentOrderDirection = UpdateDirection;
    }
}
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Data;

/// <summary>
/// Setting class to define column ShowInSearchResultsOption used on returned result entities from target Api in the Ui
/// </summary>
public class ShowInSearchResultsOption
{
    private ShowInSearchResultsType? _currentShowInSearchResultsOption = null;

    private ShowInSearchResultsType? _setShowInSearchResultsOption = null;

    /// <summary>
    /// Property PropertyName used to associate ShowInSearchResultsOption with a PropertyName in result entity
    /// </summary>
    public string? PropertyName { get; set; }

    /// <summary>
    /// Property DefaultView used as a default column display setting for this ShowInSearchResultsOption when resetting back to default settings on Ui
    /// </summary>
    public ShowInSearchResultsType DefaultShowInSearchResultsOption { get; set; }

    /// <summary>
    /// Property CurrentView used as a current column display setting for this View on Ui
    /// </summary>
    public ShowInSearchResultsType CurrentShowInSearchResultsOption
    {
        get
        {
            _currentShowInSearchResultsOption ??= DefaultShowInSearchResultsOption;
            return (ShowInSearchResultsType)_currentShowInSearchResultsOption;
        }
        set
        {
            _currentShowInSearchResultsOption = value;
        }
    }

    /// <summary>
    /// Property SetView used as a temporary column display setting when user manually amending View settings in Ui before applying them
    /// </summary>
    public ShowInSearchResultsType SetShowInSearchResultsOption
    {
        get
        {
            _setShowInSearchResultsOption ??= CurrentShowInSearchResultsOption;
            return (ShowInSearchResultsType)_setShowInSearchResultsOption;
        }
        set
        {
            _setShowInSearchResultsOption = value;
        }
    }

    /// <summary>
    /// Property IsSetViewDisabled used to decide in Ui if View can be manually set or not
    /// </summary>
    public bool IsSetViewDisabled { 
        get {
            return CurrentShowInSearchResultsOption.Equals(ShowInSearchResultsType.Always)
                || CurrentShowInSearchResultsOption.Equals(ShowInSearchResultsType.Never);
        }
    }

    /// <summary>
    /// Method to reset current and set View to default display settings
    /// </summary>
    public void ResetView()
    {
        _currentShowInSearchResultsOption = null;
        _setShowInSearchResultsOption = null;
    }

    /// <summary>
    /// Method to update the View to new value
    /// </summary>
    /// <param name="UpdateType"></param>
    public void UpdateSetView(ShowInSearchResultsType UpdateType)
    {
        SetShowInSearchResultsOption = UpdateType;
    }
}
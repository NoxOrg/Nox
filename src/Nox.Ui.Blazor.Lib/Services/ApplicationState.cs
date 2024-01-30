namespace Nox.Ui.Blazor.Lib.Services;

public class ApplicationState
{
    public event Action<string>? PageTitleChanged;

    private string _pageTitle = "Home";

    public ApplicationState() { }

    public ApplicationState(string defaultTitle)
    {
        PageTitle = defaultTitle;
    }

    public string PageTitle
    {
        get => _pageTitle;
        set
        {
            if (_pageTitle != value)
            {
                _pageTitle = value;
                PageTitleChanged?.Invoke(_pageTitle);
            }
        }
    }
}

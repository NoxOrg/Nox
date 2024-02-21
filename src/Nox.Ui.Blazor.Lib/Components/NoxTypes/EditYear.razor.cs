using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditYear : ComponentBase
{

    #region Declarations

    [Parameter]
    public int? Year { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool HideSpinButtons { get; set; } = true;

    [Parameter]
    public EventCallback<int?> YearChanged { get; set; }

    [Parameter]
    public bool AllowFutureOnly { get; set; } = false;

    [Parameter]
    public ushort MinValue { get; set; } = 0;

    [Parameter]
    public ushort MaxValue { get; set; } = 9999;

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    public readonly string Format = "####";

    [Parameter]
    public YearTypeOptions? TypeOptions { get; set; }

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            AllowFutureOnly = TypeOptions.AllowFutureOnly;
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
        }
    }

    protected async Task OnYearChanged(string newValue)
    {
        if (int.TryParse(newValue, out int parsedInt))
        {
            Year = parsedInt;
        }
        else
        {
            Year = null;
        }

        await YearChanged.InvokeAsync(Year);
    }
}
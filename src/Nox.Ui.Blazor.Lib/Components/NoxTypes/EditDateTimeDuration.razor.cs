using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditDateTimeDuration : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public DateTimeDurationTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public double MinDuration { get; set; } = 1;

    [Parameter]
    public TimeUnit TimeUnit { get; set; } = TimeUnit.Day;

    [Parameter]
    public string MinDurationCustomFormat { get; set; } = string.Empty;

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            TimeUnit = TypeOptions.TimeUnit;
            MinDuration = TypeOptions.MinDuration;
            MinDurationCustomFormat = TypeOptions.MinDurationCustomFormat;            
        }
    }
}
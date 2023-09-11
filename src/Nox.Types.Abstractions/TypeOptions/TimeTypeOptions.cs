namespace Nox.Types;

public class TimeTypeOptions
{
    // MinTimeTicks is the ticks for the midnight time 00:00:00.000 AM
    public long MinTimeTicks { get; set; } = 0;

    // MaxTimeTicks is the max tick value for the time in the day. It is calculated using DateTime.Today.AddTicks(-1).TimeOfDay.Ticks.
    public long MaxTimeTicks { get; set; } = 863_999_999_999;
}

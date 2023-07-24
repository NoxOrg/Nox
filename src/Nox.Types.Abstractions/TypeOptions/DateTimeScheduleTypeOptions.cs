namespace Nox.Types;

public class DateTimeScheduleTypeOptions : INoxTypeOptions
{
    public Frequency Frequency { get; set; } = Frequency.Daily;
    public int FrequencyValue { get; set; } = 0;
}


using System;

namespace Nox.Types;

public class DateTimeDurationTypeOptions : INoxTypeOptions
{
    public static readonly int DefaultMaxDurationDays = 365;
    public static readonly int DefaultMaxDurationHours = 0;
    public static readonly int DefaultMaxDurationMinutes = 0;
    public static readonly int DefaultMaxDurationSeconds = 0;
    public static readonly int DefaultMaxDurationMilliseconds = 0;

    public static readonly int DefaultMinDurationDays = 0;
    public static readonly int DefaultMinDurationHours = 0;
    public static readonly int DefaultMinDurationMinutes = 0;
    public static readonly int DefaultMinDurationSeconds = 0;
    public static readonly int DefaultMinDurationMilliseconds = 0;

    public int MaxDurationDays { get; set; } = DefaultMaxDurationDays;
    public int MaxDurationHours { get; set; } = DefaultMaxDurationHours;
    public int MaxDurationMinutes { get; set; } = DefaultMaxDurationMinutes;
    public int MaxDurationSeconds { get; set; } = DefaultMaxDurationSeconds;
    public int MaxDurationMilliseconds { get; set; } = DefaultMaxDurationMilliseconds;
    public TimeSpan GetMaxDuration() => new TimeSpan(MaxDurationDays, MaxDurationHours, MaxDurationMinutes, MaxDurationSeconds, MaxDurationMilliseconds).Duration();

    public int MinDurationDays { get; set; } = DefaultMinDurationDays;
    public int MinDurationHours { get; set; } = DefaultMinDurationHours;
    public int MinDurationMinutes { get; set; } = DefaultMinDurationMinutes;
    public int MinDurationSeconds { get; set; } = DefaultMinDurationSeconds;
    public int MinDurationMilliseconds { get; set; } = DefaultMinDurationMilliseconds;
    public TimeSpan GetMinDuration() => new TimeSpan(MinDurationDays, MinDurationHours, MinDurationMinutes, MinDurationSeconds, MinDurationMilliseconds).Duration();
}

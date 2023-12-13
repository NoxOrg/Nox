using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class DateTimeDurationTypeOptions : INoxTypeOptions
{
    public static readonly double DefaultMaxDuration = 365;
    public static readonly double DefaultMinDuration = 0;
    public static readonly TimeUnit DefaultTimeUnit = TimeUnit.Day;

    /// <summary>
    /// Gets or sets the maximum duration as decimal value.
    /// </summary>
    /// <remarks>
    /// This field is used to calculate max duration in case that TimeUnit is anything other than <see cref="TimeUnit.CustomFormat"/>
    /// </remarks>
    public double MaxDuration { get; set; } = DefaultMaxDuration;

    /// <summary>
    /// Gets or sets the maximum duration as custom format string (e.g. dd:HH:mm:ss).
    /// </summary>
    /// <remarks>
    /// This field is used to calculate max duration in case that TimeUnit is <see cref="TimeUnit.CustomFormat"/>
    /// </remarks>
    public string MaxDurationCustomFormat { get; set; } = GetDurationAsCustomFormatString(DefaultMaxDuration);

    /// <summary>
    /// Gets or sets the minimum duration as decimal value.
    /// </summary>
    /// <remarks>
    /// This field is used to calculate min duration in case that TimeUnit is anything other than <see cref="TimeUnit.CustomFormat"/>
    /// </remarks>
    public double MinDuration { get; set; } = DefaultMinDuration;

    /// <summary>
    /// Gets or sets the minimum duration as custom format string (e.g. HH:mm:ss).
    /// </summary>
    /// <remarks>
    /// This field is used to calculate min duration in case that TimeUnit is <see cref="TimeUnit.CustomFormat"/>
    /// </remarks>
    public string MinDurationCustomFormat { get; set; } = GetDurationAsCustomFormatString(DefaultMinDuration);

    /// <summary>
    /// Gets or sets the time unit for the min and max durations.
    /// </summary>
    public TimeUnit TimeUnit { get; set; } = DefaultTimeUnit;

    /// <summary>
    /// Gets the maximum duration based on the TimeUnit.
    /// </summary>
    public TimeSpan GetMaxDuration()
        => GetDuration(MaxDuration, MaxDurationCustomFormat);

    /// <summary>
    /// Gets the minimum duration based on the TimeUnit.
    /// </summary>
    public TimeSpan GetMinDuration()
        => GetDuration(MinDuration, MinDurationCustomFormat);

    private TimeSpan GetDuration(double value, string customFormatValue)
        => TimeUnit switch
        {
            TimeUnit.Day => TimeSpan.FromDays(value),
            TimeUnit.Hour => TimeSpan.FromHours(value),
            TimeUnit.Minute => TimeSpan.FromMinutes(value),
            TimeUnit.Second => TimeSpan.FromSeconds(value),
            TimeUnit.Millisecond => TimeSpan.FromMilliseconds(value),
            TimeUnit.CustomFormat => TimeSpan.Parse(customFormatValue),
            _ => throw new NotImplementedException()
        };

    private static string GetDurationAsCustomFormatString(double value)
    {
        return DefaultTimeUnit switch
        {
            TimeUnit.Day => TimeSpan.FromDays(value).ToString("c"),
            TimeUnit.Hour => TimeSpan.FromHours(value).ToString("c"),
            TimeUnit.Minute => TimeSpan.FromMinutes(value).ToString("c"),
            TimeUnit.Second => TimeSpan.FromSeconds(value).ToString("c"),
            TimeUnit.Millisecond => TimeSpan.FromMilliseconds(value).ToString("c"),
            _ => throw new NotImplementedException()
        };
    }
}

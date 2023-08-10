using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The time converter.
/// </summary>

public class TimeConverter : ValueConverter<Time, TimeSpan>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeConverter"/> class.
    /// </summary>
    public TimeConverter() : base(time => time.Value.ToTimeSpan(), timeSpanValue => Time.FromDatabase(TimeOnly.FromTimeSpan(timeSpanValue))) { }
}

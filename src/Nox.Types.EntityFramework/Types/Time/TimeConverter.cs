using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The time converter.
/// </summary>

public class TimeConverter : ValueConverter<Time, System.DateTime>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeConverter"/> class.
    /// </summary>
    public TimeConverter() : base(time => System.DateTime.SpecifyKind(time.Value.ToDateTime(), DateTimeKind.Utc), convertFromProviderExpression: timeValue => Time.FromDatabase(timeValue)) { }
}

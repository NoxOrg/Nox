using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
///   Class for time zone codes conversions.
/// </summary>
public class TimeZoneCodeConverter : ValueConverter<TimeZoneCode, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeZoneCodeConverter" /> class.
    /// </summary>
    public TimeZoneCodeConverter() : base(timeZoneCode => timeZoneCode.Value, timeZoneCodeValue => TimeZoneCode.From(timeZoneCodeValue)) { }
}
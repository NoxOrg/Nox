using Nox.Reference;

namespace Nox.Types.Extensions;

public static class TimeZoneCodeExtensions
{
    public static Reference.TimeZone GetReferenceTimeZone(this TimeZoneCode timeZoneCode)
    {
        return World.TimeZones.GetById(timeZoneCode.Value)!;
    }
    
    public static TimeZoneCode GetTimeZoneCode(this Reference.TimeZone referenceTimeZone)
    {
        return TimeZoneCode.From(referenceTimeZone.Code);
    }
}
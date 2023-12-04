using System;

namespace Nox.Types;
public interface IDateTimeRange
{
    DateTimeOffset End { get; }
    DateTimeOffset Start { get; }
}
public interface IWritableDateTimeRange
{
    DateTimeOffset End { set; }
    DateTimeOffset Start { set; }
}
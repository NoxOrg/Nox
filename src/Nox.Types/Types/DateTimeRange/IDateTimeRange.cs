using System;

namespace Nox.Types;
public interface IDateTimeRange
{
    DateTimeOffset End { get; }
    DateTimeOffset Start { get; }
}
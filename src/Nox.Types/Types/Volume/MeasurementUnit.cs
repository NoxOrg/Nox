using System;

namespace Nox.Types;

public abstract class MeasurementUnit : IComparable
{
    public int Id { get; }
    public string Name { get; }
    public string Symbol { get; }

    protected MeasurementUnit(int id, string name, string symbol)
    {
        Id = id;
        Name = name;
        Symbol = symbol;
    }

    public int CompareTo(object obj)
        => Id.CompareTo(((MeasurementUnit)obj).Id);

    public override bool Equals(object obj)
    {
        if (obj is not MeasurementUnit otherValue)
        {
            return false;
        }

        var isEqualType = GetType().Equals(obj.GetType());
        var isEqualId = Id.Equals(otherValue.Id);

        return isEqualType && isEqualId;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString() => Symbol;

    public static bool operator ==(MeasurementUnit? a, MeasurementUnit? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(MeasurementUnit? a, MeasurementUnit? b)
    {
        return !(a == b);
    }
}

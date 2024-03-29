﻿namespace Nox.Types.Common;

public abstract class MeasurementUnit : SmartEnumeration
{
    public string Symbol { get; }

    protected MeasurementUnit(int id, string name, string symbol)
        : base(id, name)
    {
        Symbol = symbol;
    }

    public override string ToString() => Symbol;
}

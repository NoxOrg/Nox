﻿using Nox.Types.Common;

namespace Nox.Types;

public sealed class DistanceUnit : MeasurementUnit
{
    public static readonly DistanceUnit Kilometer = new(1, "Kilometer", "km");
    public static readonly DistanceUnit Mile = new(2, "Mile", "mi");

    private DistanceUnit(int id, string name, string symbol) : base(id, name, symbol)
    {
    }
}

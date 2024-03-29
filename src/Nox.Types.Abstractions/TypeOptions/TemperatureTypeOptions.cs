﻿namespace Nox.Types;

public class TemperatureTypeOptions : INoxTypeOptions
{
    // Database Creation Properties
    public TemperatureTypeUnit PersistAs { get; set; } = TemperatureTypeUnit.Celsius;
    //Creation Properties
    public TemperatureTypeUnit Units { get; set; } = TemperatureTypeUnit.Celsius;
}
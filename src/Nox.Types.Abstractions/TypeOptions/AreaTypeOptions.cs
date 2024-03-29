﻿namespace Nox.Types;

public class AreaTypeOptions: INoxTypeOptions
{
    private const double DefaultMinArea = 0;
    private const double DefaultMaxArea = 999_999_999_999_999;
    
    // Validation Properties
    public double MinValue { get; set; } = DefaultMinArea;
    public double MaxValue { get; set; } = DefaultMaxArea;

    // Creation Properties
    public AreaTypeUnit Units { get; set; } = AreaTypeUnit.SquareMeter;

    // Database Creation Properties
    public AreaTypeUnit PersistAs { get; set; } = AreaTypeUnit.SquareMeter;
}

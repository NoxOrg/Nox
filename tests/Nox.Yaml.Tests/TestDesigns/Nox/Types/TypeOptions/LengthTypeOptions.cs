﻿using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class LengthTypeOptions
{
    private const double DefaultMinLength = 0;
    private const double DefaultMaxLength = 999_999_999_999_999;

    // Validation Properties
    public double MinValue { get; set; } = DefaultMinLength;
    public double MaxValue { get; set; } = DefaultMaxLength;

    // Creation Properties
    public LengthTypeUnit Units { get; set; } = LengthTypeUnit.Meter;

    // Database Creation Properties
    public LengthTypeUnit PersistAs { get; set; } = LengthTypeUnit.Meter;
}
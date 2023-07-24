using System;

namespace Nox.Types;

public class NuidTypeOptions
{
    public string? Prefix { get; set; }
    public string Separator { get; set; } = string.Empty;
    public string[] PropertyNames { get; set; } = Array.Empty<string>();
}
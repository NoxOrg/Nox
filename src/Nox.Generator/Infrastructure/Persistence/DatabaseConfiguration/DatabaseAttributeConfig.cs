namespace Nox.Generator.Infrastructure.Persistence.DatabaseConfiguration;

internal sealed class DatabaseAttributeConfig : IDatabaseAttributeConfig
{
    public bool IsSingleProperty { get; set; }
    public string? HasColumnType { get; set; }
    public string? HasConversionTypeFullName { get; set; }
    public uint? HasMaxLength { get; set; }
    public bool IsUnicode { get; set; } = false;
}
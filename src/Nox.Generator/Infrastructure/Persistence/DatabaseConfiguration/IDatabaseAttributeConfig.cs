namespace Nox.Generator.Infrastructure.Persistence.DatabaseConfiguration;

internal interface IDatabaseAttributeConfig
{
    public bool IsSingleProperty { get;}
    public string? HasColumnType { get; }
    public string? HasConversionTypeFullName { get; }
    public uint? HasMaxLength { get; }
    public bool IsUnicode { get; }
}
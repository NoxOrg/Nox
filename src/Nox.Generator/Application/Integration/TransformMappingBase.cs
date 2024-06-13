using System;
using Nox.Generator.Application.Integration.MappingHelpers;

namespace Nox.Generator.Application.Integration;

internal class TransformMappingBase
{
    public TransformMappingField? Source { get; set; }
    public TransformMappingField? Target { get; set; }
    public bool IsNullable { get; set; }
}

internal class TransformMappingField
{
    public string? Name { get; set; }
    public MappingDataType? DataType { get; set; }
    public string? DataTypeName { get; set; }
    public string? Default { get; set; }
} 
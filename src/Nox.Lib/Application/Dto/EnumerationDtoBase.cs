using Nox.Types;

namespace Nox.Application.Dto;

/// <summary>
/// A  Enumeration Id and Translated Name
/// </summary>
public abstract partial record EnumerationDtoBase
{
    /// <summary>
    /// Enum Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Default Translation for the Enum Name
    /// </summary>
    public string Name { get; set; } = null!;
}

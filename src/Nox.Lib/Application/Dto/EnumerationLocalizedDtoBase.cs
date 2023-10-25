namespace Nox.Application.Dto;

/// <summary>
/// Enumeration Translated name
/// </summary>
public abstract partial record EnumerationLocalizedDtoBase
{
    /// <summary>
    /// Enumeration Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Culture Code for the translated name
    /// </summary>
    public string CultureCode { get; set; } = null!;

    /// <summary>
    /// Default Translation for the Enumeration Name
    /// </summary>
    public string Name { get; set; } = null!;

 }

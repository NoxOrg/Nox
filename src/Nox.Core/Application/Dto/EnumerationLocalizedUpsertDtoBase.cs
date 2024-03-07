using System.ComponentModel.DataAnnotations;

namespace Nox.Application.Dto;

public abstract partial record EnumerationLocalizedUpsertDtoBase
{
    /// <summary>
    /// Translation for the Enumeration Name
    /// </summary>
    [Required(ErrorMessage = "Name is required for the enumeration translation")]
    public string Name { get; set; } = null!;
}
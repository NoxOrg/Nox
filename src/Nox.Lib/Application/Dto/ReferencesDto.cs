namespace Nox.Application.Dto;

/// <summary>
/// Represents a DTO for passing multiple entity keys.
/// </summary>
/// <typeparam name="T">Type of the entity keys.</typeparam>
public partial class ReferencesDto<T>
{
    /// <summary>
    /// Gets or sets the collection of entity keys.
    /// </summary>
    /// <remarks>
    /// This property holds an IEnumerable of entity keys to be used in requests for the endpoints.
    /// </remarks>
    public IEnumerable<T> References { get; set; } = Array.Empty<T>();
}

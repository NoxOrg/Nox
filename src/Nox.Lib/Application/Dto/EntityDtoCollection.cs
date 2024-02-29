namespace Nox.Application.Dto;

public class EntityDtoCollection<T>
{
    public IEnumerable<T> Value { get; set; } = Array.Empty<T>();
}

namespace Nox.Application.Dto;

public class EntityDtoCollection<T>
{
    public IEnumerable<T> Values { get; set; } = Array.Empty<T>();
}

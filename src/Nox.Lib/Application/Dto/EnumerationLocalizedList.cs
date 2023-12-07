namespace Nox.Application.Dto;

public class EnumerationLocalizedList<T> where T : EnumerationLocalizedDtoBase
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
}
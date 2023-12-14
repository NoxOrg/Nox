namespace Nox.Application.Dto;

public class EnumerationLocalizedListDto<T> where T : EnumerationLocalizedDtoBase
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
}
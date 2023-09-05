using System.Collections;

namespace Nox.Types.EntityFramework.Configurations;

public class ConcurrentEntityConfiguration : IEnumerable<NoxSimpleTypeDefinition>
{
    private readonly List<NoxSimpleTypeDefinition> _configuration;

    public ConcurrentEntityConfiguration()
    {
        _configuration = new List<NoxSimpleTypeDefinition>
        {
            new()
            {
                Name = "Etag",
                Type = NoxType.Guid,
                IsRequired = true,
            }
        };
    }

    public IEnumerator<NoxSimpleTypeDefinition> GetEnumerator()
        => _configuration.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}

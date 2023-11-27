using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Extensions
{
    public static class DomainExtensions
    {
        public static IEnumerable<Entity> GetLocalizedEntities(this Domain domain)
            => domain.Entities.Where(entity => entity.IsLocalized);
    }
}

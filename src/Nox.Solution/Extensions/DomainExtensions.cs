using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Extensions
{
    public static class DomainExtensions
    {
        public static IEnumerable<Entity> GetLocalizedEntities(this Domain domain)
            => domain.Entities.Where(entity => entity.IsLocalized);

        public static bool HasEntity(this Solution.Domain domain, string name)
            => domain.Entities.Any(e => e.Persistence.TableName!.Equals(name, StringComparison.OrdinalIgnoreCase));

    }
}

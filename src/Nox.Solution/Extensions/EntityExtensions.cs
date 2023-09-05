using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Extensions;

public static class EntityExtensions
{
    public static Entity? TryGetParent(this Entity ownedEntity, IEnumerable<Entity> allEntities)
    {
        if (!ownedEntity.IsOwnedEntity) 
        {
            return null;
        }

        return allEntities.FirstOrDefault(e => 
            e.OwnedRelationships?.Any(o => o.Entity == ownedEntity.Name && !o.WithSingleEntity) == true);
    }
}
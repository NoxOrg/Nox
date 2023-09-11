using Nox.Domain;
using Nox.Solution;

namespace Nox.Factories;

/// <summary>
/// Map Dtos to the entities 
/// </summary>
public interface IEntityMapper<E> where E : IEntity
{
    /// <summary>
    /// Set the entity properties with the dto data
    /// </summary>
    void MapToEntity(E entity, Entity entityDefinition, dynamic dto);
    /// <summary>
    /// Update a subset of the entity properties
    /// </summary>    
    /// <param name="entity">Entity to update</param>
    /// <param name="entityDefinition">Entity Definition</param>
    /// <param name="updatedProperties">Properties to update</param>
    void PartialMapToEntity(E entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties);
}

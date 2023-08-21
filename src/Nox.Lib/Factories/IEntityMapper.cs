using Nox.Domain;
using Entity = Nox.Solution.Entity;

namespace Nox.Factories;

/// <summary>
/// Service to set the entity properties 
/// </summary>
public interface IEntityMapper<E> where E : IEntity
{
    /// <summary>
    /// Set the entity properties with the dto data
    /// </summary>
    void MapToEntity(E entity, Entity entityDefinition, dynamic dto);
    /// <summary>
    /// Update some entity properties
    /// </summary>    
    /// <param name="entity">Entity to update</param>
    /// <param name="entityDefinition">Entity Definition</param>
    /// <param name="updatedProperties">Properties to update</param>
    void PartialMapToEntity(E entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties);
}

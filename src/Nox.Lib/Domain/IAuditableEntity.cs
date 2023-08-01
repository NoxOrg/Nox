
namespace Nox.Domain
{
    internal interface IDeleteEntity
    {
        /// <summary>
        /// The date and time when this entity was deleted (in Coordinated Universal Time).
        /// </summary>
        DateTime? DeletedAtUtc { get;}

        /// <summary>
        /// The user that deleted the entity.
        /// </summary>
        string? DeletedBy { get; }

        /// <summary>
        /// Set the entity as deleted (Soft Deleted).
        /// </summary>
        bool? Deleted { get;}

        /// <summary>
        /// Deletes the Entity
        /// </summary>
        public abstract void Delete();        
    }
}

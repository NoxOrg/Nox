
namespace Nox.Domain
{
    public abstract partial class AuditableEntityBase: IDeleteEntity
    {
        /// <summary>
        /// The date and time when this entity was first created (in Coordinated Universal Time).
        /// </summary>
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// The user that created the entity.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// The date and time when this entity was last updated (in Coordinated Universal Time).
        /// </summary>
        public DateTime? UpdatedAtUtc { get; set; }

        /// <summary>
        /// The user that last updated the entity.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// The date and time when this entity was deleted (in Coordinated Universal Time).
        /// </summary>
        public DateTime? DeletedAtUtc { get; private set; }

        /// <summary>
        /// The user that deleted the entity.
        /// </summary>
        public string? DeletedBy { get; private  set; }

        /// <summary>
        /// Set the entity as deleted (Soft Deleted).
        /// </summary>
        public bool? Deleted { get; private set; }

        /// <summary>
        /// Deletes the Entity
        /// </summary>
        public virtual void Delete()
        {
            Deleted = true;
            DeletedAtUtc = DateTime.UtcNow;
            // TODO DeletedBy to be done by interceptor on db context...
        }

    }
}

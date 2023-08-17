namespace Nox.Domain
{
    public abstract partial class AuditableEntityBase : IEntity, IAuditCreated, IAuditUpdated, IAuditDeleted
    {
        protected AuditableEntityBase()
        {
            // TODO: CreatedBy to be done by interceptor on db context...
        }

        /// <summary>
        /// The date and time when this entity was first created (in Coordinated Universal Time).
        /// </summary>
        public virtual Types.DateTime CreatedAtUtc { get; private set; } = Types.DateTime.From(DateTime.UtcNow);

        /// <summary>
        /// The user that created the entity.
        /// </summary>
        public virtual Types.User CreatedBy { get; private set; } = Types.User.From(Guid.Empty.ToString());

        /// <summary>
        /// The system that the entity created from.
        /// </summary>
        public virtual Types.Text CreatedVia { get; private set; } = Types.Text.From(string.Empty);

        /// <summary>
        /// The date and time when this entity was last updated (in Coordinated Universal Time).
        /// </summary>
        public virtual Types.DateTime? LastUpdatedAtUtc { get; private set; } = null;

        /// <summary>
        /// The user that last updated the entity.
        /// </summary>
        public virtual Types.User? LastUpdatedBy { get; private set; } = null;

        /// <summary>
        /// The system that the entity updated via.
        /// </summary>
        public virtual Types.Text? LastUpdatedVia { get; private set; } = null;

        /// <summary>
        /// The date and time when this entity was deleted (in Coordinated Universal Time).
        /// </summary>
        public virtual Types.DateTime? DeletedAtUtc { get; private set; } = null;

        /// <summary>
        /// The user that deleted the entity.
        /// </summary>
        public virtual Types.User? DeletedBy { get; private set; } = null;

        /// <summary>
        /// The system that the entity deleted via.
        /// </summary>
        public virtual Types.Text? DeletedVia { get; private set; } = null;

        /// <summary>
        /// Soft delete state of the entity.
        /// </summary>
        public virtual Types.Boolean IsDeleted => Types.Boolean.From(DeletedAtUtc != null);

        /// <summary>
        /// Marks the entity as Created
        /// </summary>
        /// <param name="user">The user who is responsible for the operation.</param>
        /// <param name="system">The system which the operation is made from.</param>
        public virtual void Created(Types.User user, Types.Text system)
        {
            //Default values are fine.
            CreatedBy = user;
            CreatedVia = system;
        }

        public virtual void Updated(Types.User user, Types.Text system)
        {
            LastUpdatedAtUtc = Types.DateTime.From(System.DateTime.UtcNow);

            LastUpdatedBy = user;
            LastUpdatedVia = system;
        }

        public virtual void Deleted(Types.User user, Types.Text system)
        {
            DeletedAtUtc = Types.DateTime.From(System.DateTime.UtcNow);

            DeletedBy = user;
            DeletedVia = system;
        }

        //These are temporary, we will remove them when we have the ICurrentSession or ICurrentSession
        #region temporary

        public virtual void Created()
        {
            Created(user: Types.User.From(Guid.Empty.ToString()), system: Types.Text.From("N/A"));
        }

        public virtual void Updated()
        {
            Updated(user: Types.User.From(Guid.Empty.ToString()), system: Types.Text.From("N/A"));
        }

        public virtual void Deleted()
        {
            Deleted(user: Types.User.From(Guid.Empty.ToString()), system: Types.Text.From("N/A"));
        }

        #endregion
    }
}

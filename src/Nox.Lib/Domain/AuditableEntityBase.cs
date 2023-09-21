namespace Nox.Domain;

public abstract partial class AuditableEntityBase : IEntity, IEntityAuditCreated, IEntityAuditUpdated, IEntityAuditDeleted
{
    private static readonly string DefaultUser = Guid.Empty.ToString();
    private static readonly string DefaultSystem = "N/A";

    protected AuditableEntityBase()
    {
        // TODO: CreatedBy to be done by interceptor on db context...
    }

    /// <summary>
    /// The date and time when this entity was first created (in Coordinated Universal Time).
    /// </summary>
    public virtual System.DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    /// <summary>
    /// The user that created the entity.
    /// </summary>
    public virtual string CreatedBy { get; private set; } = DefaultUser;

    /// <summary>
    /// The system that the entity created from.
    /// </summary>
    public virtual string CreatedVia { get; private set; } = DefaultSystem;

    /// <summary>
    /// The date and time when this entity was last updated (in Coordinated Universal Time).
    /// </summary>
    public virtual System.DateTime? LastUpdatedAtUtc { get; private set; } = null;

    /// <summary>
    /// The user that last updated the entity.
    /// </summary>
    public virtual string? LastUpdatedBy { get; private set; } = null;

    /// <summary>
    /// The system that the entity updated via.
    /// </summary>
    public virtual string? LastUpdatedVia { get; private set; } = null;

    /// <summary>
    /// The date and time when this entity was deleted (in Coordinated Universal Time).
    /// </summary>
    public virtual System.DateTime? DeletedAtUtc { get; private set; } = null;

    /// <summary>
    /// The user that deleted the entity.
    /// </summary>
    public virtual string? DeletedBy { get; private set; } = null;

    /// <summary>
    /// The system that the entity deleted via.
    /// </summary>
    public virtual string? DeletedVia { get; private set; } = null;

    /// <summary>
    /// Soft delete state of the entity.
    /// </summary>
    public virtual bool IsDeleted => DeletedAtUtc != null;

    /// <summary>
    /// Marks the entity as Created
    /// </summary>
    /// <param name="user">The user who is responsible for the operation.</param>
    /// <param name="system">The system which the operation is made from.</param>
    public virtual void Created(string user, string system)
    {
        //Default values are fine.
        CreatedBy = user;
        CreatedVia = system;
    }

    /// <summary>
    /// Marks the entity as Updated
    /// </summary>
    /// <param name="user">The user who is responsible for the operation.</param>
    /// <param name="system">The system which the operation is made from.</param>
    public virtual void Updated(string user, string system)
    {
        LastUpdatedAtUtc = System.DateTime.UtcNow;

        LastUpdatedBy = user;
        LastUpdatedVia = system;
    }

    /// <summary>
    /// Marks the entity as Deleted
    /// </summary>
    /// <param name="user">The user who is responsible for the operation.</param>
    /// <param name="system">The system which the operation is made from.</param>
    public virtual void Deleted(string user, string system)
    {
        DeletedAtUtc = System.DateTime.UtcNow;

        DeletedBy = user;
        DeletedVia = system;
    }
}

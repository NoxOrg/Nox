namespace Nox.Domain;

public interface IEntityAuditDeleted
{
    Types.User? DeletedBy { get; }
    Types.Text? DeletedVia { get; }
    Types.DateTime? DeletedAtUtc { get; }
    Types.Boolean IsDeleted { get; }
}
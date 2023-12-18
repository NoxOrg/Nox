namespace Nox.Domain;

public interface IEntityAuditDeleted
{
    string? DeletedBy { get; }
    string? DeletedVia { get; }
    System.DateTime? DeletedAtUtc { get; }
    bool IsDeleted { get; }
}
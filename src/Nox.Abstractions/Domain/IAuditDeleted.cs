namespace Nox.Domain;

public interface IAuditDeleted
{
    string? DeletedBy { get; }
    string? DeletedVia { get; }
    System.DateTime? DeletedAtUtc { get; }
    bool IsDeleted { get; }
}
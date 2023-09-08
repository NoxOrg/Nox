namespace Nox.Domain;

public interface IAuditUpdated
{
    string? LastUpdatedBy { get; }
    string? LastUpdatedVia { get; }
    System.DateTime? LastUpdatedAtUtc { get; }
}
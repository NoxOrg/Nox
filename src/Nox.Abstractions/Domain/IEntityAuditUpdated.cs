namespace Nox.Domain;

public interface IEntityAuditUpdated
{
    string? LastUpdatedBy { get; }
    string? LastUpdatedVia { get; }
    System.DateTime? LastUpdatedAtUtc { get; }
}
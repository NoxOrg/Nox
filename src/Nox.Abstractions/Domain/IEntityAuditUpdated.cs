namespace Nox.Domain;

public interface IEntityAuditUpdated
{
    Types.User? LastUpdatedBy { get; }
    Types.Text? LastUpdatedVia { get; }
    Types.DateTime? LastUpdatedAtUtc { get; }
}
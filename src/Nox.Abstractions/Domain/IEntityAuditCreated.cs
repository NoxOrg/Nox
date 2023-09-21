namespace Nox.Domain;

public interface IEntityAuditCreated
{
    string CreatedBy { get; }
    string CreatedVia { get; }
    System.DateTime CreatedAtUtc { get; }
}

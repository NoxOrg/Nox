namespace Nox.Domain;

public interface IAuditCreated
{
    string CreatedBy { get; }
    string CreatedVia { get; }
    System.DateTime CreatedAtUtc { get; }
}

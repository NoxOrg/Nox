namespace Nox.Domain;

public interface IAuditCreated
{
    Types.User CreatedBy { get; }
    Types.Text CreatedVia { get; }
    Types.DateTime CreatedAtUtc { get; }
}

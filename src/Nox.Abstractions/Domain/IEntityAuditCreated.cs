namespace Nox.Domain;

public interface IEntityAuditCreated
{
    Types.User CreatedBy { get; }
    Types.Text CreatedVia { get; }
    Types.DateTime CreatedAtUtc { get; }
}

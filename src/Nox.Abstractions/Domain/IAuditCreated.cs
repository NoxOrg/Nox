namespace Nox.Abstractions;

public interface IAuditCreated
{
    Types.User CreatedBy { get; }
    Types.Text CreatedVia { get; }
    Types.DateTime CreatedAtUtc { get; }
}

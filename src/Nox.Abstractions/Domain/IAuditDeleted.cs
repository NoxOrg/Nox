namespace Nox.Abstractions;

public interface IAuditDeleted
{
    Types.User? DeletedBy { get; }
    Types.Text? DeletedVia { get; }
    Types.DateTime? DeletedAtUtc { get; }
    Types.Boolean IsDeleted { get; }
}
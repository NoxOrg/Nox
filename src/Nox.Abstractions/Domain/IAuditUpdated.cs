namespace Nox.Abstractions;

public interface IAuditUpdated
{
    Types.User? LastUpdatedBy { get; }
    Types.Text? LastUpdatedVia { get; }
    Types.DateTime? LastUpdatedAtUtc { get; }
}
namespace Nox.Domain
{
    public interface IAuditUpdated
    {
        Types.User? LastUpdatedBy { get; }
        Types.Text? LastUpdatedVia { get; }
        Types.DateTime? LastUpdatedAtUtc { get; }
    }
}
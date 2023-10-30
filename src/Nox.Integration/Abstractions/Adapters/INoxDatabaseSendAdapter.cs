namespace Nox.Integration.Abstractions.Adapters;

public interface INoxDatabaseSendAdapter: INoxSendAdapter
{
    string StoredProcedure { get; }
}
namespace Nox.Abstractions;

public interface INoxCommandResult
{
    public bool IsSuccess { get; }

    public string? Message { get; }
}
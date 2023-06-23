namespace Nox.Abstraction.Stubs;

public interface INoxCommandResult
{
    public bool IsSuccess { get; }

    public string? Message { get; }
}
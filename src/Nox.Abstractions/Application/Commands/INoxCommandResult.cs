namespace Nox.Application.Commands;

public interface INoxCommandResult
{
    public bool IsSuccess { get; }

    public string? Message { get; }
}
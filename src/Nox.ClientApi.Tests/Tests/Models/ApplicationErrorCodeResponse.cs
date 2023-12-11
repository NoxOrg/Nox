namespace ClientApi.Tests.Tests.Models;

public class ApplicationErrorCodeResponse
{
    public ApplicationError<Object> Error { get; set; } = null!;
}
public class ApplicationError<T> where T : class
{
    public string Message { get; set; } = null!;
    public uint Id { get; set; }
    public string Code { get; set; } = null!;
    public T Details { get; set; } = null!;
}

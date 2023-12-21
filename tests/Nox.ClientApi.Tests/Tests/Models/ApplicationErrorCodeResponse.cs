namespace ClientApi.Tests.Tests.Models;


public class ApplicationErrorCodeResponse<T> where T : class
{
    public ApplicationError<T> Error { get; set; } = null!;
}
public class ApplicationErrorCodeResponse
{
    public ApplicationError<Object> Error { get; set; } = null!;
}
public class ApplicationError<T> where T : class
{
    public string Message { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Code { get; set; } = null!;
    public T Details { get; set; } = null!;
}

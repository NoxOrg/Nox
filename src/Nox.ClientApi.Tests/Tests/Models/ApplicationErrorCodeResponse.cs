namespace ClientApi.Tests.Tests.Models;

public class ApplicationErrorCodeResponse
{
    public ApplicationError Error { get; set; } = null!;
}
public class ApplicationError
{
    public string Message { get; set; } = null!;
    public uint Id { get; set; }
    public string Code { get; set; } = null!;
}

namespace Nox.Exceptions;

public sealed class BadRequestInvalidFieldException : BadRequestException
{
    public BadRequestInvalidFieldException() : base($"Unknown field or invalid field type. Please review your request payload.", "bad_request_invalid_field")
    {
     
    } 
}
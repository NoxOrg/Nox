using System.Net;

namespace Nox.Exceptions;

/// <summary>
/// Provides information that can be returned to the client in case of an exception
/// </summary>
public interface IApplicationException
{
    /// <summary>
    /// Optional: The Status code to be returned to the client in case of an Http call.
    /// </summary>
    HttpStatusCode? StatusCode { get; }

    /// <summary>
    /// A short string with a brief explanation of the error to be returned to the client
    /// Snake case is recommended
    /// </summary>
    string ErrorCode { get; }

    /// <summary>
    /// Optional: A complex object with more details about the error to be returned to the client
    /// This object will be serialized to JSON
    /// </summary>
    object? ErrorDetails { get; }
}

namespace Nox.Application.Queries;

/// <summary>
/// Base Implementation for aNox Command
/// </summary>
public abstract class QueryBase<TResponse> : IQuery
{

    /// <summary>
    /// Returning the response, use this method to override or update the response
    /// </summary>
    /// <param name="response"> the current response</param>
    /// <returns></returns>
    protected virtual TResponse OnResponse(TResponse response)
    {
        return response; 
    }
}
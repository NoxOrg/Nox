using Nox.Domain;
using Nox.Solution;

namespace Nox.Application.Commands;

/// <summary>
/// Base Implementation for a Nox Command that will affect multiple Entities
/// </summary>
public abstract class CommandCollectionBase<TRequest, TEntity> : INoxCommand where TEntity : IEntity
{
    protected NoxSolution NoxSolution { get; }

    protected Types.CultureCode DefaultCultureCode;

    protected CommandCollectionBase(NoxSolution noxSolution)
    {
        NoxSolution = noxSolution;
        DefaultCultureCode = Types.CultureCode.From(NoxSolution!.Application!.Localization!.DefaultCulture);
    }

    /// <summary>
    /// Executing the command handler, use this method to override or update the request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    protected virtual Task OnExecutingAsync(TRequest request) { return Task.CompletedTask; }

    /// <summary>
    /// Command handler completed
    /// Use this method to override, update, validate or other run custom logic regarding affected Entities
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    protected virtual Task OnCompletedAsync(TRequest request, ICollection<TEntity> entitites) { return Task.CompletedTask; }
}
using Nox.Domain;
using Nox.Solution;

namespace Nox.Application.Commands;

/// <summary>
/// Base Implementation for a Nox Command that will affect a single Entity
/// </summary>
public abstract class CommandBase<TRequest, TEntity> : INoxCommand where TEntity : IEntity
{
    protected NoxSolution NoxSolution { get; }

    protected Types.CultureCode DefaultCultureCode;


    protected CommandBase(NoxSolution noxSolution)
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
    /// Use this method to override, update, validate or other run custom logic regarding the affected Entity
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    protected virtual Task OnCompletedAsync(TRequest request, TEntity entity) { return Task.CompletedTask; }
    
    /// <summary>
    /// Command handler completed
    /// Use this method to override, update, validate or other run custom logic regarding the batch process of the updated/created/deleted Entities
    /// </summary>
    /// <param name="request"></param>
    /// <param name="entities"></param>
    protected virtual Task OnBatchCompletedAsync(TRequest request, IEnumerable<TEntity> entities) { return Task.CompletedTask; }
}

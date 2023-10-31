using Nox.Domain;
using Nox.Solution;

namespace Nox.Application.Commands;

/// <summary>
/// Base Implementation for aNox Command
/// </summary>
public abstract class CommandBase<TRequest, TEntity>: INoxCommand where TEntity : IEntity
{
    protected NoxSolution NoxSolution { get; }
    protected CommandBase(NoxSolution noxSolution)
    {
        NoxSolution = noxSolution;
    }

    protected Entity GetEntityDefinition<E>()
    {
        return NoxSolution.Domain!.GetEntityByName(typeof(E).Name);
    }

    /// <summary>
    /// Executing the command handler, use this method to override or update the request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    protected virtual Task OnExecutingAsync(TRequest request) { return Task.CompletedTask; }

    /// <summary>
    /// Command handler completed
    /// Use this method to override, update, validate or other run custom logic regarding the updated/created Entity
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    protected virtual Task OnCompletedAsync(TRequest request, TEntity entity) { return Task.CompletedTask; }

    protected Types.CultureCode GetLocalizationDefaultCultureCode()
        => Types.CultureCode.From(NoxSolution!.Application!.Localization!.DefaultCulture);
}


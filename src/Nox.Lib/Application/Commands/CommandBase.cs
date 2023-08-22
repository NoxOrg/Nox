using Microsoft.Extensions.DependencyInjection;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

namespace Nox.Application.Commands;

/// <summary>
/// Base Implementation for aNox Command
/// </summary>
public abstract class CommandBase: INoxCommand
{
    public NoxSolution NoxSolution { get; }
    public IServiceProvider ServiceProvider { get; }
    public CommandBase(NoxSolution noxSolution, IServiceProvider serviceProvider)
    {
        NoxSolution = noxSolution;
        ServiceProvider = serviceProvider;
    }
    
    public N? CreateNoxTypeForKey<E, N>(string keyName, dynamic? value) where N : INoxType
    {
        var entityDefinition = GetEntityDefinition<E>();
        var key = entityDefinition.Keys!.Single(entity => entity.Name == keyName);

        var typeFactory = ServiceProvider.GetService<INoxTypeFactory<N>>();
        return typeFactory!.CreateNoxType(key, value);
    }

    public Entity GetEntityDefinition<E>()
    {
        return NoxSolution.Domain!.GetEntityByName(typeof(E).Name);
    }
}


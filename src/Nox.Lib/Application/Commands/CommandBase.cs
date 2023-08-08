using Microsoft.Extensions.DependencyInjection;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

namespace Nox.Application.Commands;

/// <summary>
/// Nox Command base command
/// </summary>

public abstract class CommandBase
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
        var entityDefinition = NoxSolution.Domain!.GetEntityByName(typeof(E).Name);
        var key = entityDefinition.Keys!.Single(entity => entity.Name == keyName);

        var typeFactory = ServiceProvider.GetService<INoxTypeFactory<N>>();
        return typeFactory!.CreateNoxType(key, value);
    }
}


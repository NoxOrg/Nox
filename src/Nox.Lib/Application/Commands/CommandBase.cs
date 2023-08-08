using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

namespace Nox.Application.Commands;

public abstract class CommandBase<TRequest, TResponse>: IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public NoxSolution NoxSolution { get; }
    public IServiceProvider ServiceProvider { get; }
    public CommandBase(NoxSolution noxSolution, IServiceProvider serviceProvider)
    {
        NoxSolution = noxSolution;
        ServiceProvider = serviceProvider;
    }
    
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    public N? CreateNoxTypeForKey<E,N>(string keyName, dynamic? value) where N : INoxType
    {
        var entityDefinition = NoxSolution.Domain!.GetEntityByName(typeof(E).Name);
        var key = entityDefinition.Keys!.Single(entity => entity.Name == keyName);

        var typeFactory = ServiceProvider.GetService<INoxTypeFactory<N>>();
        return typeFactory!.CreateNoxType(key, value);        
    }    
}


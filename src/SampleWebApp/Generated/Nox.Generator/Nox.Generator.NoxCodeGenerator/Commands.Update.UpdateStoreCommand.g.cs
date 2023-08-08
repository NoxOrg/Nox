// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;


namespace SampleWebApp.Application.Commands;

public record UpdateStoreCommand(StoreDto EntityDto) : IRequest;

public class UpdateStoreCommandHandler: CommandBase, IRequestHandler<UpdateStoreCommand>
{
    public SampleWebAppDbContext DbContext { get; }    

    public  UpdateStoreCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(10);
        return;
        //var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        ////TODO for nuid property or key needs to call ensure id        
        //DbContext.Stores.Add(entityToCreate);
        //await DbContext.SaveChangesAsync();
        //return entityToCreate.Id;
    }
}
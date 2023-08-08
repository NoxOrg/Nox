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

public record UpdateAllNoxTypeCommand(AllNoxTypeDto EntityDto) : IRequest;

public class UpdateAllNoxTypeCommandHandler: CommandBase, IRequestHandler<UpdateAllNoxTypeCommand>
{
    public SampleWebAppDbContext DbContext { get; }    

    public  UpdateAllNoxTypeCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task Handle(UpdateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(10);
        return;
        //var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        ////TODO for nuid property or key needs to call ensure id        
        //DbContext.AllNoxTypes.Add(entityToCreate);
        //await DbContext.SaveChangesAsync();
        //return entityToCreate.Id;
    }
}